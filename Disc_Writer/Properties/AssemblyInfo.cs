using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Resources;

[assembly: FileIOPermission(SecurityAction.RequestMinimum, Unrestricted = true)]
[assembly: ReflectionPermission(SecurityAction.RequestMinimum, Unrestricted = true)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, UnmanagedCode = true, ControlEvidence = true)]
[assembly: UIPermission(SecurityAction.RequestMinimum, Unrestricted = true)]
[assembly: KeyContainerPermission(SecurityAction.RequestMinimum, Unrestricted = true)]

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Disc Creator")]
[assembly: AssemblyDescription("Создатель Дисков ЭУМК - программа для автоматизированного создания дисков с электронным учебным методическим комплексом.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Ерёмин Андрей")]
[assembly: AssemblyProduct("Disc Creator")]
[assembly: AssemblyCopyright("Copyright © Ерёмин Андрей 2009 - 2011")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("48bba33e-39da-4804-ad68-a023e1b1f80b")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.82")]
[assembly: AssemblyFileVersion("1.0.0.82")]



[assembly: NeutralResourcesLanguageAttribute("ru")]
