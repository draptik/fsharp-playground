System:
```
$ uname -a
Linux raven 4.9.8-040908-generic #201702040431 SMP Sat Feb 4 09:32:59 UTC 2017 x86_64 x86_64 x86_64 GNU/Linux

$ dotnet --version
1.0.4

$ apt search dotnet|grep installed

WARNING: apt does not have a stable CLI interface. Use with caution in scripts.

dotnet-dev-1.0.1/xenial,now 1.0.1-1 amd64 [installed]
dotnet-dev-1.0.4/xenial,now 1.0.4-1 amd64 [installed]
dotnet-host/xenial,now 2.0.0-preview1-002111-00-1 amd64 [installed,automatic]
dotnet-hostfxr-1.0.1/xenial,now 1.0.1-1 amd64 [installed,automatic]
dotnet-hostfxr-1.1.0/xenial,now 1.1.0-1 amd64 [installed,automatic]
dotnet-sharedframework-microsoft.netcore.app-1.0.4/xenial,now 1.0.4-1 amd64 [installed,automatic]
dotnet-sharedframework-microsoft.netcore.app-1.0.5/xenial,now 1.0.5-1 amd64 [installed,automatic]
dotnet-sharedframework-microsoft.netcore.app-1.1.1/xenial,now 1.1.1-1 amd64 [installed,automatic]
dotnet-sharedframework-microsoft.netcore.app-1.1.2/xenial,now 1.1.2-1 amd64 [installed,automatic]
```

# Initial setup

The following command creates a template project for xunit.net:
```
dotnet new xunit -lang f#
```

- Add unit tests from exersism.io site.
- Implement...

```
dotnet restore
```

# Usage

```
dotnet test
```

# Refactoring

## Refactoring 1

Initially all implementation code was located in `Tests.fs`. The following steps are needed to move the code to separate files:

### Create new file for shared functionality

Certain functions are needed by all implementations. These functions are located in `All.fs`. In VS Code, create a new file `All.fs` (sibling of `Tests.fs`)

The following functions are shared/used by multiple implementations:

- `IsDividableBy`
- `(|DividableBy|_|)`

Cut & paste this functions from `Tests.fs` to `All.fs`.

These functions must be within an F# `module`.

TODO My current understanding of an F# `module` is: A collection of functions which are not associated with a `type` (similar to a static class in C#).

### "Register" the new module in fsproj

To make the project aware of the new file `All.fs` it must be registered in the `fsproj` file.

I have not found a way to do this from within VS Code. Although there is a VS Code method called `F# Add current file to project`. Currently this method seems to do nothing.

Adding the new file `All.fs` to `fsproj` can be done manually by replacing 

```xml
  <ItemGroup>
    <Compile Include="**/*.fs" />
  </ItemGroup>
```
with

```xml
  <ItemGroup>
    <Compile Include="All.fs" />
    <Compile Include="Tests.fs" />
  </ItemGroup>
```
I am sure that the tooling support from within VS Code will improve over time.

### Create new file for each implementation

- In VS Code, create a new file (sibling to `Tests.fs`). For example `Version1.fs`.
- Create a module for each version
- Import `All` module with `open All`
- Move function from `Tests.fs` to `Version<n>.fs`
- Rename function to `IsLeapYear`
- Add `Version<n>.fs` to `fsproj` file
- Import new Version module in `Tests.fs`
- Fix naming in `Tests.isLeapYear` wrapper.
- Cleanup: Remove unused `open` statements, etc
- Ensure correct ordering in `fsproj` file!

The final `fsproj` section should look like this:

```xml
  <ItemGroup>
    <Compile Include="All.fs" />
    <Compile Include="Version1.fs" />
    <Compile Include="Version2.fs" />
    <Compile Include="Version3.fs" />
    <Compile Include="Version4.fs" />
    <Compile Include="Version5.fs" />
    <Compile Include="Tests.fs" />
  </ItemGroup>
```

TODO Ordering of compile instructions is very important in F#!

None of the tests have changed. All tests should still be green.