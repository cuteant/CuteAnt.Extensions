using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("System.Reflection.Metadata")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyDescription("System.Reflection.Metadata Library (Flavor=Debug)")]
#else
[assembly: AssemblyConfiguration("Retail")]
[assembly: AssemblyDescription("System.Reflection.Metadata Library (Flavor=Retail)")]
#endif

[assembly: InternalsVisibleTo("System.Reflection.Metadata.Tests" + CuteAnt.AssemblyInfo.PublicKeyString)]
