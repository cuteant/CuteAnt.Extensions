// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyCopyright("Copyright © Microsoft, dotnetframework")]
[assembly: AssemblyProduct("AspNetCore")]
[assembly: AssemblyTrademark(CuteAnt.AssemblyInfo.AssemblyEmail)]
[assembly: AssemblyCulture("")]
#if !PORTABLE
[assembly: ComVisible(false)]
#endif
[assembly: CLSCompliant(false)]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: NeutralResourcesLanguage("en-US")]
#if NET40 || PORTABLE
namespace System.Reflection
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    internal sealed class AssemblyMetadataAttribute : Attribute
    {
        public AssemblyMetadataAttribute(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
#endif