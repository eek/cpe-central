﻿#region Using directives

using System.Windows;
using System.Windows.Media.TextFormatting;

#endregion

namespace ICSharpCode.AvalonEdit.Rendering
{
    internal sealed class VisualLineTextParagraphProperties : TextParagraphProperties
    {
        internal TextRunProperties defaultTextRunProperties;
        internal bool firstLineInParagraph;
        internal double indent;
        internal double tabSize;
        internal TextWrapping textWrapping;

        public override double DefaultIncrementalTab
        {
            get { return tabSize; }
        }

        public override FlowDirection FlowDirection
        {
            get { return FlowDirection.LeftToRight; }
        }

        public override TextAlignment TextAlignment
        {
            get { return TextAlignment.Left; }
        }

        public override double LineHeight
        {
            get { return double.NaN; }
        }

        public override bool FirstLineInParagraph
        {
            get { return firstLineInParagraph; }
        }

        public override TextRunProperties DefaultTextRunProperties
        {
            get { return defaultTextRunProperties; }
        }

        public override TextWrapping TextWrapping
        {
            get { return textWrapping; }
        }

        public override TextMarkerProperties TextMarkerProperties
        {
            get { return null; }
        }

        public override double Indent
        {
            get { return indent; }
        }
    }
}