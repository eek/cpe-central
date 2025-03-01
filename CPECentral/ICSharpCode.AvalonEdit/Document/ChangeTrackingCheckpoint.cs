﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Document
{
    /// <summary>
    ///     <para>A checkpoint that allows tracking changes to a TextDocument.</para>
    ///     <para>
    ///         Use <see cref="TextDocument.CreateSnapshot(out ChangeTrackingCheckpoint)" /> to create a checkpoint.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <see cref="ChangeTrackingCheckpoint" /> class allows tracking document changes, even from background
    ///         threads.
    ///     </para>
    ///     <para>
    ///         Once you have two checkpoints, you can call <see cref="ChangeTrackingCheckpoint.GetChangesTo" /> to retrieve
    ///         the complete list
    ///         of document changes that happened between those versions of the document.
    ///     </para>
    /// </remarks>
    public sealed class ChangeTrackingCheckpoint
    {
        // Object that is unique per document.
        // Used to determine if two checkpoints belong to the same document.
        // We don't use a reference to the document itself to allow the GC to reclaim the document memory
        // even if there are still references to checkpoints.
        private readonly object documentIdentifier;

        // 'value' is the change from the previous checkpoint to this checkpoint
        // TODO: store the change in the older checkpoint instead - if only a reference to the
        // newest document version exists, the GC should be able to collect all DocumentChangeEventArgs.
        private readonly int id;
        private readonly DocumentChangeEventArgs value;
        private ChangeTrackingCheckpoint next;

        internal ChangeTrackingCheckpoint(object documentIdentifier)
        {
            this.documentIdentifier = documentIdentifier;
        }

        internal ChangeTrackingCheckpoint(object documentIdentifier, DocumentChangeEventArgs value, int id)
        {
            this.documentIdentifier = documentIdentifier;
            this.value = value;
            this.id = id;
        }

        internal ChangeTrackingCheckpoint Append(DocumentChangeEventArgs change)
        {
            Debug.Assert(next == null);
            next = new ChangeTrackingCheckpoint(documentIdentifier, change, unchecked(id + 1));
            return next;
        }

        /// <summary>
        ///     Creates a change tracking checkpoint for the specified document.
        ///     This method is thread-safe.
        ///     If you need a ChangeTrackingCheckpoint that's consistent with a snapshot of the document,
        ///     use <see cref="TextDocument.CreateSnapshot(out ChangeTrackingCheckpoint)" />.
        /// </summary>
        public static ChangeTrackingCheckpoint Create(TextDocument document)
        {
            if (document == null) {
                throw new ArgumentNullException("document");
            }
            return document.CreateChangeTrackingCheckpoint();
        }

        /// <summary>
        ///     Gets whether this checkpoint belongs to the same document as the other checkpoint.
        /// </summary>
        public bool BelongsToSameDocumentAs(ChangeTrackingCheckpoint other)
        {
            if (other == null) {
                throw new ArgumentNullException("other");
            }
            return documentIdentifier == other.documentIdentifier;
        }

        /// <summary>
        ///     Compares the age of this checkpoint to the other checkpoint.
        /// </summary>
        /// <remarks>This method is thread-safe.</remarks>
        /// <exception cref="ArgumentException">Raised if 'other' belongs to a different document than this checkpoint.</exception>
        /// <returns>
        ///     -1 if this checkpoint is older than <paramref name="other" />.
        ///     0 if <c>this</c>==<paramref name="other" />.
        ///     1 if this checkpoint is newer than <paramref name="other" />.
        /// </returns>
        public int CompareAge(ChangeTrackingCheckpoint other)
        {
            if (other == null) {
                throw new ArgumentNullException("other");
            }
            if (other.documentIdentifier != documentIdentifier) {
                throw new ArgumentException("Checkpoints do not belong to the same document.");
            }
            // We will allow overflows, but assume that the maximum distance between checkpoints is 2^31-1.
            // This is guaranteed on x86 because so many checkpoints don't fit into memory.
            return Math.Sign(unchecked(id - other.id));
        }

        /// <summary>
        ///     Gets the changes from this checkpoint to the other checkpoint.
        ///     If 'other' is older than this checkpoint, reverse changes are calculated.
        /// </summary>
        /// <remarks>This method is thread-safe.</remarks>
        /// <exception cref="ArgumentException">Raised if 'other' belongs to a different document than this checkpoint.</exception>
        public IEnumerable<DocumentChangeEventArgs> GetChangesTo(ChangeTrackingCheckpoint other)
        {
            int result = CompareAge(other);
            if (result < 0) {
                return GetForwardChanges(other);
            }
            if (result > 0) {
                return other.GetForwardChanges(this).Reverse().Select(change => change.Invert());
            }
            return Empty<DocumentChangeEventArgs>.Array;
        }

        private IEnumerable<DocumentChangeEventArgs> GetForwardChanges(ChangeTrackingCheckpoint other)
        {
            // Return changes from this(exclusive) to other(inclusive).
            ChangeTrackingCheckpoint node = this;
            do {
                node = node.next;
                yield return node.value;
            } while (node != other);
        }

        /// <summary>
        ///     Calculates where the offset has moved in the other buffer version.
        /// </summary>
        /// <remarks>This method is thread-safe.</remarks>
        /// <exception cref="ArgumentException">Raised if 'other' belongs to a different document than this checkpoint.</exception>
        public int MoveOffsetTo(ChangeTrackingCheckpoint other, int oldOffset, AnchorMovementType movement)
        {
            int offset = oldOffset;
            foreach (DocumentChangeEventArgs e in GetChangesTo(other)) {
                offset = e.GetNewOffset(offset, movement);
            }
            return offset;
        }
    }
}