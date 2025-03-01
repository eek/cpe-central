﻿#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary>
    ///     Abstact base class for all types that can contain child nodes
    /// </summary>
    public abstract class AXmlContainer : AXmlObject
    {
        /// <summary> Create new container </summary>
        protected AXmlContainer()
        {
            Children = new AXmlObjectCollection<AXmlObject>();
        }

        #region Helpper methods

        private ObservableCollection<AXmlElement> elements;

        /// <summary> Gets direcly nested elements (non-recursive) </summary>
        public ObservableCollection<AXmlElement> Elements
        {
            get
            {
                if (elements == null) {
                    elements = new FilteredCollection<AXmlElement, AXmlObjectCollection<AXmlObject>>(Children);
                }
                return elements;
            }
        }

        internal AXmlObject FirstChild
        {
            get { return Children[0]; }
        }

        internal AXmlObject LastChild
        {
            get { return Children[Children.Count - 1]; }
        }

        #endregion

        /// <summary>
        ///     Children of the node.  It is read-only.
        ///     Note that is has CollectionChanged event.
        /// </summary>
        public AXmlObjectCollection<AXmlObject> Children { get; private set; }

        /// <inheritdoc />
        public override IEnumerable<AXmlObject> GetSelfAndAllChildren()
        {
            return (new AXmlObject[] {this}).Flatten(
                delegate(AXmlObject i) {
                    var container = i as AXmlContainer;
                    if (container != null) {
                        return container.Children;
                    }
                    return null;
                }
                );
        }

        /// <summary>
        ///     Gets a child fully containg the given offset.
        ///     Goes recursively down the tree.
        ///     Specail case if at the end of attribute or text
        /// </summary>
        public AXmlObject GetChildAtOffset(int offset)
        {
            foreach (AXmlObject child in Children) {
                if ((child is AXmlAttribute || child is AXmlText) && offset == child.EndOffset) {
                    return child;
                }
                if (child.StartOffset < offset && offset < child.EndOffset) {
                    var container = child as AXmlContainer;
                    if (container != null) {
                        return container.GetChildAtOffset(offset);
                    }
                    return child;
                }
            }
            return this; // No childs at offset
        }

        // Only these four methods should be used to modify the collection

        /// <summary> To be used exlucively by the parser </summary>
        internal void AddChild(AXmlObject item)
        {
            // Childs can be only added to newly parsed items
            Assert(Parent == null, "I have to be new");
            Assert(item.IsCached, "Added item must be in cache");
            // Do not set parent pointer
            Children.InsertItemAt(Children.Count, item);
        }

        /// <summary> To be used exlucively by the parser </summary>
        internal void AddChildren(IEnumerable<AXmlObject> items)
        {
            // Childs can be only added to newly parsed items
            Assert(Parent == null, "I have to be new");
            // Do not set parent pointer
            Children.InsertItemsAt(Children.Count, items.ToList());
        }

        /// <summary>
        ///     To be used exclusively by the children update algorithm.
        ///     Insert child and keep links consistent.
        /// </summary>
        private void InsertChild(int index, AXmlObject item)
        {
            AXmlParser.Log("Inserting {0} at index {1}", item, index);

            Assert(Document != null, "Can not insert to dangling object");
            Assert(item.Parent != this, "Can not own item twice");

            SetParentPointersInTree(item);

            Children.InsertItemAt(index, item);

            Document.OnObjectInserted(index, item);
        }

        /// <summary> Recursively fix all parent pointer in a tree </summary>
        /// <remarks>
        ///     Cache constraint:
        ///     If cached item has parent set, then the whole subtree must be consistent and document set
        /// </remarks>
        private void SetParentPointersInTree(AXmlObject item)
        {
            // All items come from the parser cache

            if (item.Parent == null) {
                // Dangling object - either a new parser object or removed tree (still cached)
                item.Parent = this;
                item.Document = Document;
                var container = item as AXmlContainer;
                if (container != null) {
                    foreach (AXmlObject child in container.Children) {
                        container.SetParentPointersInTree(child);
                    }
                }
            }
            else if (item.Parent == this) {
                // If node is attached and then deattached, it will have null parent pointer
                //   but valid subtree - so its children will alredy have correct parent pointer
                //   like in this case
                // item.DebugCheckConsistency(false);
                // Rest of the tree is consistent - do not recurse
            }
            else {
                // From cache & parent set => consitent subtree
                // item.DebugCheckConsistency(false);
                // The parent (or any futher parents) can not be part of parsed document
                //   becuase otherwise this item would be included twice => safe to change parents
                // Maintain cache constraint by setting parents to null
                foreach (AXmlObject ancest in item.GetAncestors().ToList()) {
                    ancest.Parent = null;
                }
                item.Parent = this;
                // Rest of the tree is consistent - do not recurse
            }
        }

        /// <summary>
        ///     To be used exclusively by the children update algorithm.
        ///     Remove child, set parent to null and notify the document
        /// </summary>
        private void RemoveChild(int index)
        {
            AXmlObject removed = Children[index];
            AXmlParser.Log("Removing {0} at index {1}", removed, index);

            // Stop tracking if the object can not be used again
            if (!removed.IsCached) {
                Document.Parser.TrackedSegments.RemoveParsedObject(removed);
            }

            // Null parent pointer
            Assert(removed.Parent == this, "Inconsistent child");
            removed.Parent = null;

            Children.RemoveItemAt(index);

            Document.OnObjectRemoved(index, removed);
        }

        /// <summary> Verify that the subtree is consistent.  Only in debug build. </summary>
        /// <remarks> Parent pointers might be null or pointing somewhere else in parse tree </remarks>
        internal override void DebugCheckConsistency(bool checkParentPointers)
        {
            base.DebugCheckConsistency(checkParentPointers);
            AXmlObject prevChild = null;
            int myStartOffset = StartOffset;
            int myEndOffset = EndOffset;
            foreach (AXmlObject child in Children) {
                Assert(child.Length != 0, "Empty child");
                if (checkParentPointers) {
                    Assert(child.Parent != null, "Null parent reference");
                    Assert(child.Parent == this, "Inccorect parent reference");
                }
                if (Document != null) {
                    Assert(child.Document != null, "Child has null document");
                    Assert(child.Document == Document, "Child is in different document");
                }
                if (IsCached) {
                    Assert(child.IsCached, "Child not in cache");
                }
                Assert(myStartOffset <= child.StartOffset && child.EndOffset <= myEndOffset,
                    "Child not within parent text range");
                if (prevChild != null) {
                    Assert(prevChild.EndOffset <= child.StartOffset, "Overlaping childs");
                }
                child.DebugCheckConsistency(checkParentPointers);
                prevChild = child;
            }
        }

        /// <remarks>
        ///     Note the the method is not called recuively.
        ///     Only the helper methods are recursive.
        /// </remarks>
        internal void UpdateTreeFrom(AXmlContainer srcContainer)
        {
            StartOffset = srcContainer.StartOffset; // Force the update
            UpdateDataFrom(srcContainer);
            RemoveChildrenNotIn(srcContainer.Children);
            InsertAndUpdateChildrenFrom(srcContainer.Children);
        }

        private void RemoveChildrenNotIn(IList<AXmlObject> srcList)
        {
            Dictionary<int, AXmlObject> srcChildren = srcList.ToDictionary(i => i.StartOffset);
            for (int i = 0; i < Children.Count;) {
                AXmlObject child = Children[i];
                AXmlObject srcChild;

                if (srcChildren.TryGetValue(child.StartOffset, out srcChild) && child.CanUpdateDataFrom(srcChild)) {
                    // Keep only one item with given offset (we might have several due to deletion)
                    srcChildren.Remove(child.StartOffset);
                    // If contaner that needs updating
                    var childAsContainer = child as AXmlContainer;
                    if (childAsContainer != null && child.LastUpdatedFrom != srcChild) {
                        childAsContainer.RemoveChildrenNotIn(((AXmlContainer) srcChild).Children);
                    }
                    i++;
                }
                else {
                    RemoveChild(i);
                }
            }
        }

        private void InsertAndUpdateChildrenFrom(IList<AXmlObject> srcList)
        {
            for (int i = 0; i < srcList.Count; i++) {
                // End of our list?
                if (i == Children.Count) {
                    InsertChild(i, srcList[i]);
                    continue;
                }
                AXmlObject child = Children[i];
                AXmlObject srcChild = srcList[i];

                if (child.CanUpdateDataFrom(srcChild)) {
                    // includes offset test
                    // Does it need updating?
                    if (child.LastUpdatedFrom != srcChild) {
                        child.UpdateDataFrom(srcChild);
                        var childAsContainer = child as AXmlContainer;
                        if (childAsContainer != null) {
                            childAsContainer.InsertAndUpdateChildrenFrom(((AXmlContainer) srcChild).Children);
                        }
                    }
                }
                else {
                    InsertChild(i, srcChild);
                }
            }
            Assert(Children.Count == srcList.Count, "List lengths differ after update");
        }
    }
}