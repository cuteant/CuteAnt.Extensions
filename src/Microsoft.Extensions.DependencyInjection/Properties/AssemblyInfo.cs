using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Microsoft.Extensions.DependencyInjection")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyDescription("Microsoft.Extensions.DependencyInjection Library (Flavor=Debug)")]
#else
[assembly: AssemblyConfiguration("Retail")]
[assembly: AssemblyDescription("Microsoft.Extensions.DependencyInjection Library (Flavor=Retail)")]
#endif
