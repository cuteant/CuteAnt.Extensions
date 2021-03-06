﻿// <auto-generated />
namespace Microsoft.Extensions.Configuration
{
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    internal static class Resources
    {
        private static readonly ResourceManager _resourceManager = ConfigSR.ResourceManager;

        /// <summary>
        /// A configuration source is not registered. Please register one before setting a value.
        /// </summary>
        internal static string Error_NoSources
        {
            get => GetString("Error_NoSources");
        }

        /// <summary>
        /// A configuration source is not registered. Please register one before setting a value.
        /// </summary>
        internal static string FormatError_NoSources()
            => GetString("Error_NoSources");

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
