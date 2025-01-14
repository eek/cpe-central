﻿#region Using directives

using System;
using System.Globalization;

#endregion

namespace ICSharpCode.AvalonEdit.Document
{
    /// <summary>
    ///     A line/column position.
    ///     Text editor lines/columns are counted started from one.
    /// </summary>
    /// <remarks>
    ///     The document provides the methods <see cref="TextDocument.GetLocation" /> and
    ///     <see cref="TextDocument.GetOffset(TextLocation)" /> to convert between offsets and TextLocations.
    /// </remarks>
    public struct TextLocation : IComparable<TextLocation>, IEquatable<TextLocation>
    {
        /// <summary>
        ///     Represents no text location (0, 0).
        /// </summary>
        public static readonly TextLocation Empty = new TextLocation(0, 0);

        private readonly int x;
        private readonly int y;

        /// <summary>
        ///     Creates a TextLocation instance.
        ///     <para>
        ///         Warning: the parameters are (line, column).
        ///         Not (column, line) as in ICSharpCode.TextEditor!
        ///     </para>
        /// </summary>
        public TextLocation(int line, int column)
        {
            y = line;
            x = column;
        }

        /// <summary>
        ///     Gets the line number.
        /// </summary>
        public int Line
        {
            get { return y; }
        }

        /// <summary>
        ///     Gets the column number.
        /// </summary>
        public int Column
        {
            get { return x; }
        }

        /// <summary>
        ///     Gets whether the TextLocation instance is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return x <= 0 && y <= 0; }
        }

        #region IComparable<TextLocation> Members

        /// <summary>
        ///     Compares two text locations.
        /// </summary>
        public int CompareTo(TextLocation other)
        {
            if (this == other) {
                return 0;
            }
            if (this < other) {
                return -1;
            }
            return 1;
        }

        #endregion

        #region IEquatable<TextLocation> Members

        /// <summary>
        ///     Equality test.
        /// </summary>
        public bool Equals(TextLocation other)
        {
            return this == other;
        }

        #endregion

        /// <summary>
        ///     Gets a string representation for debugging purposes.
        /// </summary>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "(Line {1}, Col {0})", x, y);
        }

        /// <summary>
        ///     Gets a hash code.
        /// </summary>
        public override int GetHashCode()
        {
            return unchecked (87*x.GetHashCode() ^ y.GetHashCode());
        }

        /// <summary>
        ///     Equality test.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is TextLocation)) {
                return false;
            }
            return (TextLocation) obj == this;
        }

        /// <summary>
        ///     Equality test.
        /// </summary>
        public static bool operator ==(TextLocation left, TextLocation right)
        {
            return left.x == right.x && left.y == right.y;
        }

        /// <summary>
        ///     Inequality test.
        /// </summary>
        public static bool operator !=(TextLocation left, TextLocation right)
        {
            return left.x != right.x || left.y != right.y;
        }

        /// <summary>
        ///     Compares two text locations.
        /// </summary>
        public static bool operator <(TextLocation left, TextLocation right)
        {
            if (left.y < right.y) {
                return true;
            }
            if (left.y == right.y) {
                return left.x < right.x;
            }
            return false;
        }

        /// <summary>
        ///     Compares two text locations.
        /// </summary>
        public static bool operator >(TextLocation left, TextLocation right)
        {
            if (left.y > right.y) {
                return true;
            }
            if (left.y == right.y) {
                return left.x > right.x;
            }
            return false;
        }

        /// <summary>
        ///     Compares two text locations.
        /// </summary>
        public static bool operator <=(TextLocation left, TextLocation right)
        {
            return !(left > right);
        }

        /// <summary>
        ///     Compares two text locations.
        /// </summary>
        public static bool operator >=(TextLocation left, TextLocation right)
        {
            return !(left < right);
        }
    }
}