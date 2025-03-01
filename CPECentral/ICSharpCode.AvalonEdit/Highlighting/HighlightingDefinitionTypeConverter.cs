﻿#region Using directives

using System;
using System.ComponentModel;
using System.Globalization;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting
{
    /// <summary>
    ///     Converts between strings and <see cref="IHighlightingDefinition" /> by treating the string as the definition name
    ///     and calling
    ///     <c>HighlightingManager.Instance.<see cref="HighlightingManager.GetDefinition">GetDefinition</see>(name)</c>.
    /// </summary>
    public sealed class HighlightingDefinitionTypeConverter : TypeConverter
    {
        /// <inheritdoc />
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof (string)) {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        /// <inheritdoc />
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var definitionName = value as string;
            if (definitionName != null) {
                return HighlightingManager.Instance.GetDefinition(definitionName);
            }
            return base.ConvertFrom(context, culture, value);
        }

        /// <inheritdoc />
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof (string)) {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        /// <inheritdoc />
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
            Type destinationType)
        {
            var definition = value as IHighlightingDefinition;
            if (definition != null && destinationType == typeof (string)) {
                return definition.Name;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}