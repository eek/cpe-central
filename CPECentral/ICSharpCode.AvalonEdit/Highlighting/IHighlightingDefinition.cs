﻿#region Using directives

using System.Collections.Generic;
using System.ComponentModel;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting
{
    /// <summary>
    ///     A highlighting definition.
    /// </summary>
    [TypeConverter(typeof (HighlightingDefinitionTypeConverter))]
    public interface IHighlightingDefinition
    {
        /// <summary>
        ///     Gets the name of the highlighting definition.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Gets the main rule set.
        /// </summary>
        HighlightingRuleSet MainRuleSet { get; }

        /// <summary>
        ///     Gets the list of named highlighting colors.
        /// </summary>
        IEnumerable<HighlightingColor> NamedHighlightingColors { get; }

        /// <summary>
        ///     Gets a rule set by name.
        /// </summary>
        /// <returns>The rule set, or null if it is not found.</returns>
        HighlightingRuleSet GetNamedRuleSet(string name);

        /// <summary>
        ///     Gets a named highlighting color.
        /// </summary>
        /// <returns>The highlighting color, or null if it is not found.</returns>
        HighlightingColor GetNamedColor(string name);
    }

    /// <summary>
    ///     Extension of IHighlightingDefinition to avoid breaking changes in the API.
    /// </summary>
    public interface IHighlightingDefinition2 : IHighlightingDefinition
    {
        /// <summary>
        ///     Gets the list of properties.
        /// </summary>
        IDictionary<string, string> Properties { get; }
    }
}