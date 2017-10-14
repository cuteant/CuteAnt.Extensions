using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Microsoft.Extensions.Configuration.Abstractions")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyDescription("Microsoft.Extensions.Configuration.Abstractions Library (Flavor=Debug)")]
#else
[assembly: AssemblyConfiguration("Retail")]
[assembly: AssemblyDescription("Microsoft.Extensions.Configuration.Abstractions Library (Flavor=Retail)")]
#endif
