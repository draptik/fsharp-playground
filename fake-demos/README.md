# FAKE, F# Make

## Installation

### Windows

`choco install fake -pre`

### Linux

Download FAKE Portable directly from the homepage. Note: This requires a working .NET Core installation.

https://github.com/fsharp/FAKE/releases

-> `fake-dotnetcore-portable.zip`

## Hello World

FAKE version 5 is written in .NET Core.

Documentation is a bit sketchy at the moment... (the example `build.fsx` file linked from the Getting started section has more than 1k LOC).

Finally found this thread for creating a hello world example: https://github.com/fsharp/FAKE/issues/1675

`build.fsx`:
```
printfn "test"
```

- `fake run build.fsx`

Another thread: https://github.com/fsharp/FAKE/issues/1722

Another thread: https://github.com/fsharp/FAKE/issues/1744


## demo2

Create 2 dotnet projects and a solution file:

- `dotnet new console -o SomeAppConsole`
- `dotnet new xunit -o SomeAppConsole.Tests`
- `dotnet new sln -n SomeApp`
- `dotnet sln add SomeAppConsole/SomeAppConsole.csproj`
- `dotnet sln add SomeAppConsole.Tests/SomeAppConsole.Tests.csproj`
- `dotnet add SomeAppConsole.Tests/SomeAppConsole.Tests.csproj reference SomeAppConsole/SomeAppConsole.csproj`

Add Paket for dependency management:

- `mkdir .paket`
- `cp ../paket-demos/paket.bootstrap.exe .paket/paket.exe`
- `touch paket.dependencies`
- `touch SomeAppConsole/paket.references`
- `touch SomeAppConsole.Tests/paket.references`

Content of `paket.depencies`:
```
source https://nuget.org/api/v2
nuget Xunit
nuget FluentAssertions
```

Content of `SomeAppConsole.Tests/paket.references`:
```
Xunit
FluentAssertions
```

- `.paket/paket.exe install`
- `dotnet test`

