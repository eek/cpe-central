﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using ICSharpCode.AvalonEdit.Document;

#endregion

namespace ICSharpCode.AvalonEdit.Search
{
    internal class RegexSearchStrategy : ISearchStrategy
    {
        private readonly bool matchWholeWords;
        private readonly Regex searchPattern;

        public RegexSearchStrategy(Regex searchPattern, bool matchWholeWords)
        {
            if (searchPattern == null) {
                throw new ArgumentNullException("searchPattern");
            }
            this.searchPattern = searchPattern;
            this.matchWholeWords = matchWholeWords;
        }

        #region ISearchStrategy Members

        public IEnumerable<ISearchResult> FindAll(ITextSource document, int offset, int length)
        {
            int endOffset = offset + length;
            foreach (Match result in searchPattern.Matches(document.Text)) {
                int resultEndOffset = result.Length + result.Index;
                if (offset > result.Index || endOffset < resultEndOffset) {
                    continue;
                }
                if (matchWholeWords &&
                    (!IsWordBorder(document, result.Index) || !IsWordBorder(document, resultEndOffset))) {
                    continue;
                }
                yield return new SearchResult {StartOffset = result.Index, Length = result.Length, Data = result};
            }
        }

        public ISearchResult FindNext(ITextSource document, int offset, int length)
        {
            return FindAll(document, offset, length).FirstOrDefault();
        }

        public bool Equals(ISearchStrategy other)
        {
            var strategy = other as RegexSearchStrategy;
            return strategy != null &&
                   strategy.searchPattern.ToString() == searchPattern.ToString() &&
                   strategy.searchPattern.Options == searchPattern.Options &&
                   strategy.searchPattern.RightToLeft == searchPattern.RightToLeft;
        }

        #endregion

        private static bool IsWordBorder(ITextSource document, int offset)
        {
            return
                TextUtilities.GetNextCaretPosition(document, offset - 1, LogicalDirection.Forward,
                    CaretPositioningMode.WordBorder) == offset;
        }
    }

    internal class SearchResult : TextSegment, ISearchResult
    {
        public Match Data { get; set; }

        #region ISearchResult Members

        public string ReplaceWith(string replacement)
        {
            return Data.Result(replacement);
        }

        #endregion
    }
}