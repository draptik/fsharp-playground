# Paket - an alternative to NuGet?

- [https://fsprojects.github.io/Paket/](Official Paket website)
- [https://dotnetmeditations.com/blog/2014/10/22/introduction-to-paket](Introduction to PAKET)
- [https://cockneycoder.wordpress.com/2017/08/07/getting-started-with-paket-part-1/](Getting Started with Paket – Part 1)
- [https://www.infoq.com/news/2016/01/paket-package-manager](Introducing Paket, a Package Manager for .NET)
- [http://krishnabhargav.github.io/paket/2015/02/23/Hello-World-Paket.html](Using Paket - a very simple introduction)


## What is Paket?

- Complete replacement for NuGet (!)
- Can still use NuGet repositories
- Can also use other sources (Github, Git repositories)

## Setup

### Sample 1: .NET Core, with NuGet, CLI

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
- install dependencies: `.paket/paket.exe install`

### Sample 3: .NET 4.7, Migration from NuGet, Visual Studio

## Paket resources

https://github.com/fsprojects/Paket/releases/latest -> download `paket.bootstrapper.exe`.