// <auto-generated />
namespace Microsoft.Extensions.Configuration.CommandLine
{
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    internal static class Resources
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("Microsoft.Extensions.Configuration.CommandLine.Resources", typeof(Resources).Assembly);

        /// <summary>
        /// Keys in switch mappings are case-insensitive. A duplicated key '{0}' was found.
        /// </summary>
        internal static string Error_DuplicatedKeyInSwitchMappings
        {
            get => GetString("Error_DuplicatedKeyInSwitchMappings");
        }

        /// <summary>
        /// Keys in switch mappings are case-insensitive. A duplicated key '{0}' was found.
        /// </summary>
        internal static string FormatError_DuplicatedKeyInSwitchMappings(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("Error_DuplicatedKeyInSwitchMappings"), p0);

        /// <summary>
        /// The switch mappings contain an invalid switch '{0}'.
        /// </summary>
        internal static string Error_InvalidSwitchMapping
        {
            get => GetString("Error_InvalidSwitchMapping");
        }

        /// <summary>
        /// The switch mappings contain an invalid switch '{0}'.
        /// </summary>
        internal static string FormatError_InvalidSwitchMapping(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("Error_InvalidSwitchMapping"), p0);

        /// <summary>
        /// The short switch '{0}' is not defined in the switch mappings.
        /// </summary>
        internal static string Error_ShortSwitchNotDefined
        {
            get => GetString("Error_ShortSwitchNotDefined");
        }

        /// <summary>
        /// The short switch '{0}' is not defined in the switch mappings.
        /// </summary>
        internal static string FormatError_ShortSwitchNotDefined(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("Error_ShortSwitchNotDefined"), p0);

        /// <summary>
        /// Unrecognized argument format: '{0}'.
        /// </summary>
        internal static string Error_UnrecognizedArgumentFormat
        {
            get => GetString("Error_UnrecognizedArgumentFormat");
        }

        /// <summary>
        /// Unrecognized argument format: '{0}'.
        /// </summary>
        internal static string FormatError_UnrecognizedArgumentFormat(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("Error_UnrecognizedArgumentFormat"), p0);

        /// <summary>
        /// Value for switch '{0}' is missing.
        /// </summary>
        internal static string Error_ValueIsMissing
        {
            get => GetString("Error_ValueIsMissing");
        }

        /// <summary>
        /// Value for switch '{0}' is missing.
        /// </summary>
        internal static string FormatError_ValueIsMissing(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("Error_ValueIsMissing"), p0);

        private static string GetString(string name, params string[] formatterNames)
        {
            var value = _resourceManager.GetString(name);

            System.Diagnostics.Debug.Assert(value != null);

            if (formatterNames != null)
            {
                for (var i = 0; i < formatterNames.Length; i++)
                {
                    value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
                }
            }

            return value;
        }
    }
}
