# Paket - an alternative to NuGet?

- [https://fsprojects.github.io/Paket/](Official Paket website)
- [https://dotnetmeditations.com/blog/2014/10/22/introduction-to-paket](Introduction to PAKET)
- [https://cockneycoder.wordpress.com/2017/08/07/getting-started-with-paket-part-1/](Getting Started with Paket – Part 1)
- [https://www.infoq.com/news/2016/01/paket-package-manager](Introducing Paket, a Package Manager for .NET)

## What is Paket?

- Complete replacement for NuGet (!)
- Can still use NuGet repositories
- Can also use other sources (Github, Git repositories)

## Setup

### Sample 1: .NET Core, with NuGet, CLI

(see demo1)

Setup:

- `dotnet new classlib -o SomeLib`
- manually added dependency to `csproj` file:
```xml
<ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="10.0.3"/>
</ItemGroup>
```

Note to self: .NET Core/NuGet projects normally do not have a `package.config` file for NuGet: Instead there is a `PackageReference` attribute in the `csproj` file (see https://docs.microsoft.com/en-us/nuget/what-is-nuget#tracking-references-and-restoring-packages for details).

### Sample 2: .NET Core, without NuGet, CLI

(see demo2)

Setup (manual):

- `dotnet new classlib -o SomeLib`
- `cd SomeLib`
- `mkdir .paket`
- `cp ../../paket.bootstrapper.exe .paket/paket.exe`
- create `paket.dependencies` file with the following content:
```
source https://nuget.org/api/v2
nuget Newtonsoft.Json
```
- install dependencies: `.paket/paket.exe install` (see Installing Newtonsoft below)
- add `paket.lock` to version control
- add `packages` folder to `.gitignore`
- create `paket.references` with the following content:
```
Newtonsoft.Json
```
- add `paket.references` to version control
- run `.paket/paket.exe install` again (this step maps the previously downloaded dependency to the actual project)

Note: The last command modifies the `csproj` file by adding the following snippet:
```xml
<Import Project=".paket\Paket.Restore.targets" />
```
### Sample 3: .NET Core solution with multiple projects, without NuGet, CLI

(see demo3)

- `dotnet new sln -n SomeApp`
- `dotnet new classlib -o SomeLib1`
- `dotnet new classlib -o SomeLib2`
- `dotnet sln add SomeLib1/SomeLib1.csproj`
- `dotnet sln add SomeLib2/SomeLib2.csproj`
- `mkdir .paket`
- `cp ../paket.bootstrapper.exe .paket/paket.exe`
- create `paket.dependencies` referencing Newtonsoft.Json
- install dependencies: `.paket/paket.exe install`
- create `paket.references` in each project (referencing Newtonsoft.Json)
- run `.paket/paket.exe install`


### Sample 4: .NET 4.7, Migration from NuGet, Visual Studio

(see demo4)

Start with a normal setup. 2 class library projects (.NET 4.7). Add Newtonsoft via NuGet to both projects.

- Copy `paket.exe` next to the solution file.
- Delete entire `packages` folder (!)
- CLI: run `paket.exe convert-from-nuget` (see sample output below)

The previous command does all the heavy lifting (`git status`):
```
modified:   SomeApp.sln
modified:   SomeLib1/SomeLib1.csproj
deleted:    SomeLib1/packages.config
modified:   SomeLib2/SomeLib2.csproj
deleted:    SomeLib2/packages.config

Untracked files:

SomeLib1/paket.references
SomeLib2/paket.references
paket.dependencies
paket.lock
```

- `./paket.exe simplify`

## Paket commands

- `paket update`
- `paket restore`
- `paket add`: Example usage: `paket add nuget Automapper project SomeLib1`

## Plugins

https://fsprojects.github.io/Paket/editor-support.html

- Visual Studio: https://github.com/fsprojects/Paket.VisualStudio (install via `Extensions and Updates`) 
- VS Code: https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-Paket

## Referencing non NuGet "things"

### Referencing source files

(see demo5)

`paket.dependencies`:
```
http file:///c:/projects/_playground/fsharp-playground/paket-demos/demo5/Bla.cs
```

Result is located in `paket-files/localhost/Bla.cs` and can be referenced from `Class1.cs`.

### Referencing git repository

(see demo5)

`paket.dependencies`:
```
git https://github.com/draptik/dotnetcore-fsharp-hello-world.git
```

Repository will be cloned and placed in `paket-files/<top-level-domain>/` (i.e. `paket-files\github.com\draptik\dotnetcore-fsharp-hello-world`).

## Paket resources

https://github.com/fsprojects/Paket/releases/latest -> download `paket.bootstrapper.exe`.

## Sample outputs

### Installing Newtonsoft
```
$ .paket/paket.exe install
Paket version 5.125.6
Resolving packages for group Main:
 - Newtonsoft.Json 10.0.3
 - Microsoft.CSharp 4.4.0
 - System.ComponentModel.TypeConverter 4.3.0
 - System.Runtime.Serialization.Formatters 4.3.0
 - System.Runtime.Serialization.Primitives 4.3.0
 - System.Xml.XmlDocument 4.3.0
 - NETStandard.Library 2.0.1
 - System.Net.Http 4.3.3
 - System.Dynamic.Runtime 4.3.0
 - System.Reflection.TypeExtensions 4.4.0
 - Microsoft.Win32.Primitives 4.3.0
 - System.AppContext 4.3.0
 - System.Collections 4.3.0
 - System.Collections.Concurrent 4.3.0
 - System.Console 4.3.0
 - System.Diagnostics.Debug 4.3.0
 - System.Diagnostics.Tools 4.3.0
 - System.Diagnostics.Tracing 4.3.0
 - System.Globalization 4.3.0
 - System.Globalization.Calendars 4.3.0
 - System.IO 4.3.0
 - System.IO.Compression 4.3.0
 - System.IO.Compression.ZipFile 4.3.0
 - System.IO.FileSystem 4.3.0
 - System.IO.FileSystem.Primitives 4.3.0
 - System.Linq 4.3.0
 - System.Linq.Expressions 4.3.0
 - System.Net.Primitives 4.3.0
 - System.Net.Sockets 4.3.0
 - System.ObjectModel 4.3.0
 - System.Reflection 4.3.0
 - System.Reflection.Extensions 4.3.0
 - System.Reflection.Primitives 4.3.0
 - System.Resources.ResourceManager 4.3.0
 - System.Runtime 4.3.0
 - System.Runtime.Extensions 4.3.0
 - System.Runtime.Handles 4.3.0
 - System.Runtime.InteropServices 4.3.0
 - System.Runtime.InteropServices.RuntimeInformation 4.3.0
 - System.Runtime.Numerics 4.3.0
 - System.Security.Cryptography.Algorithms 4.3.1
 - System.Security.Cryptography.Encoding 4.3.0
 - System.Security.Cryptography.Primitives 4.3.0
 - System.Security.Cryptography.X509Certificates 4.3.2
 - System.Text.Encoding 4.3.0
 - System.Text.Encoding.Extensions 4.3.0
 - System.Text.RegularExpressions 4.3.0
 - System.Threading 4.3.0
 - System.Threading.Tasks 4.3.0
 - System.Threading.Timer 4.3.0
 - System.Xml.ReaderWriter 4.3.0
 - System.Xml.XDocument 4.3.0
 - System.Collections.NonGeneric 4.3.0
 - System.Collections.Specialized 4.3.0
 - System.ComponentModel 4.3.0
 - System.ComponentModel.Primitives 4.3.0
 - Microsoft.NETCore.Platforms 2.0.1
 - runtime.native.System.Security.Cryptography.OpenSsl 4.3.2
 - runtime.native.System.Security.Cryptography.Apple 4.3.1
 - System.Globalization.Extensions 4.3.0
 - System.Reflection.Emit 4.3.0
 - System.Reflection.Emit.ILGeneration 4.3.0
 - runtime.native.System 4.3.0
 - runtime.native.System.IO.Compression 4.3.1
 - System.Buffers 4.4.0
 - System.Reflection.Emit.Lightweight 4.3.0
 - runtime.native.System.Net.Http 4.3.0
 - System.Diagnostics.DiagnosticSource 4.4.1
 - System.Security.Cryptography.OpenSsl 4.4.0
 - System.Security.Cryptography.Cng 4.4.0
 - System.Security.Cryptography.Csp 4.3.0
 - System.Threading.Tasks.Extensions 4.4.0
 - Microsoft.NETCore.Targets 2.0.0
 - runtime.debian.8-x64.runtime.native.System.Security.Cryptography.OpenSsl 4.3.2
 - runtime.fedora.23-x64.runtime.native.System.Security.Cryptography.OpenSsl 4.3.2
 - runtime.fedora.24-x64.runtime.native.System.Security.Cryptography.OpenSsl 4.3.2
 - runtime.opensuse.13.2-x64.runtime.native.System.Security.Cryptography.OpenSsl 4.3.2
 - runtime.opensuse.42.1-x64.runtime.native.System.Security.Cryptography.OpenSsl 4.3.2
 - runtime.osx.10.10-x64.runtime.native.System.Security.Cryptography.OpenSsl 4.3.2
 - runtime.rhel.7-x64.runtime.native.System.Security.Cryptography.OpenSsl 4.3.2
 - runtime.ubuntu.14.04-x64.runtime.native.System.Security.Cryptography.OpenSsl 4.3.2
 - runtime.ubuntu.16.04-x64.runtime.native.System.Security.Cryptography.OpenSsl 4.3.2
 - runtime.ubuntu.16.10-x64.runtime.native.System.Security.Cryptography.OpenSsl 4.3.2
 - runtime.osx.10.10-x64.runtime.native.System.Security.Cryptography.Apple 4.3.1
Locked version resolution written to C:\projects\_playground\fsharp-playground\paket-demos\demo2\paket.lock
Installing into projects:
 - Creating model and downloading packages.
Performance:
 - Resolver: 27 seconds (1 runs)
    - Runtime: 18 seconds
    - Blocked (retrieving package details): 5 seconds (34 times)
    - Blocked (retrieving package versions): 3 seconds (6 times)
    - Not Blocked (retrieving package details): 50 times
    - Not Blocked (retrieving package versions): 78 times
 - Disk IO: 2 minutes, 11 seconds
 - Average Request Time: 741 milliseconds
 - Number of Requests: 84
 - Runtime: 39 seconds
```

### Converting from NuGet Output

```
$ ./paket.exe convert-from-nuget
Paket version 5.125.6
Local NuGet feed doesn't exist: C:\projects\_playground\NugetDemo2.
Adding package Newtonsoft.Json to C:\projects\_playground\fsharp-playground\paket-demos\demo4\SomeApp\SomeLib1\paket.references into group Main
Adding package Newtonsoft.Json to C:\projects\_playground\fsharp-playground\paket-demos\demo4\SomeApp\SomeLib2\paket.references into group Main
Removing C:\projects\_playground\fsharp-playground\paket-demos\demo4\SomeApp\SomeLib1\packages.config
Removing C:\projects\_playground\fsharp-playground\paket-demos\demo4\SomeApp\SomeLib2\packages.config
Dependencies files saved to C:\projects\_playground\fsharp-playground\paket-demos\demo4\SomeApp\paket.dependencies
References file saved to C:\projects\_playground\fsharp-playground\paket-demos\demo4\SomeApp\SomeLib1\paket.references
References file saved to C:\projects\_playground\fsharp-playground\paket-demos\demo4\SomeApp\SomeLib2\paket.references
Solution C:\projects\_playground\fsharp-playground\paket-demos\demo4\SomeApp\SomeApp.sln changed
Resolving packages for group Main:
 - Newtonsoft.Json is pinned to 10.0.3
Locked version resolution written to C:\projects\_playground\fsharp-playground\paket-demos\demo4\SomeApp\paket.lock
Installing into projects:
 - Creating model and downloading packages.
Downloading Newtonsoft.Json 10.0.3
 - SomeLib1/paket.references -> SomeLib1/SomeLib1.csproj
 - SomeLib2/paket.references -> SomeLib2/SomeLib2.csproj
Performance:
 - Resolver: 2 seconds (1 runs)
    - Runtime: 90 milliseconds
    - Blocked (retrieving package details): 1 second (1 times)
    - Blocked (retrieving package versions): 833 milliseconds (1 times)
 - Disk IO: 268 milliseconds
 - Average Download Time: 697 milliseconds
 - Number of downloads: 1
 - Average Request Time: 555 milliseconds
 - Number of Requests: 3
 - Runtime: 5 seconds
```