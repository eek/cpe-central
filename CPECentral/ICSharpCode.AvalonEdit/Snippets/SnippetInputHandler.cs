﻿#region Using directives

using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.Editing;

#endregion

namespace ICSharpCode.AvalonEdit.Snippets
{
    internal sealed class SnippetInputHandler : TextAreaStackedInputHandler
    {
        private readonly InsertionContext context;

        public SnippetInputHandler(InsertionContext context)
            : base(context.TextArea)
        {
            this.context = context;
        }

        public override void Attach()
        {
            base.Attach();

            SelectElement(FindNextEditableElement(-1, false));
        }

        public override void Detach()
        {
            base.Detach();
            context.Deactivate(new SnippetEventArgs(DeactivateReason.InputHandlerDetached));
        }

        public override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Key == Key.Escape) {
                context.Deactivate(new SnippetEventArgs(DeactivateReason.EscapePressed));
                e.Handled = true;
            }
            else if (e.Key == Key.Return) {
                context.Deactivate(new SnippetEventArgs(DeactivateReason.ReturnPressed));
                e.Handled = true;
            }
            else if (e.Key == Key.Tab) {
                bool backwards = e.KeyboardDevice.Modifiers == ModifierKeys.Shift;
                SelectElement(FindNextEditableElement(TextArea.Caret.Offset, backwards));
                e.Handled = true;
            }
        }

        private void SelectElement(IActiveElement element)
        {
            if (element != null) {
                TextArea.Selection = Selection.Create(TextArea, element.Segment);
                TextArea.Caret.Offset = element.Segment.EndOffset;
            }
        }

        private IActiveElement FindNextEditableElement(int offset, bool backwards)
        {
            IEnumerable<IActiveElement> elements = context.ActiveElements.Where(e => e.IsEditable && e.Segment != null);
            if (backwards) {
                elements = elements.Reverse();
                foreach (IActiveElement element in elements) {
                    if (offset > element.Segment.EndOffset) {
                        return element;
                    }
                }
            }
            else {
                foreach (IActiveElement element in elements) {
                    if (offset < element.Segment.Offset) {
                        return element;
                    }
                }
            }
            return elements.FirstOrDefault();
        }
    }
}