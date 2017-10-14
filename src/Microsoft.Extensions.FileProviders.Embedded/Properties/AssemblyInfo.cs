using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Microsoft.Extensions.FileProviders.Embedded")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyDescription("Microsoft.Extensions.FileProviders.Embedded Library (Flavor=Debug)")]
#else
[assembly: AssemblyConfiguration("Retail")]
[assembly: AssemblyDescription("Microsoft.Extensions.FileProviders.Embedded Library (Flavor=Retail)")]
#endif
