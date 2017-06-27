
# Initial setup

The following command creates a template project for xunit.net:
```
dotnet new xunit -lang f#
```

- Add unit tests from exercism.io site.
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

## Testing frameworks

`FsUnit` seems to be the fluent assertion lib for f#. BUT it is not supported for the current version of .NET Core...

```
$ dotnet add package FsUnit.xUnit
...
error: Package FsUnit.xUnit 1.4.1 is not compatible with netcoreapp1.1 (.NETCoreApp,Version=v1.1).
```
# System

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

$ code --version
1.13.1
379d2efb5539b09112c793d3d9a413017d736f89

~/.vscode/extensions$ tree . -L 1
.
├── akamud.vscode-theme-onedark-2.0.2
├── AlanWalk.markdown-toc-1.5.5
├── annsk.alignment-0.3.0
├── dbaeumer.vscode-eslint-1.2.11
├── donjayamanne.githistory-0.2.0
├── DotJoshJohnson.xml-1.9.2
├── dzannotti.vscode-babel-coloring-0.0.4
├── EditorConfig.editorconfig-0.9.3
├── eg2.vscode-npm-script-0.2.0
├── hnw.vscode-auto-open-markdown-preview-0.0.4
├── Ionide.Ionide-FAKE-1.2.3
├── Ionide.ionide-fsharp-2.27.6
├── Ionide.ionide-paket-1.7.0
├── jchannon.csharpextensions-1.3.0
├── keyring.Lua-0.0.9
├── mohsen1.prettify-json-0.0.3
├── msjsdiag.debugger-for-chrome-3.1.5
├── ms-vscode.csharp-1.10.0
├── ms-vscode.csharp-1.11.0
├── ms-vscode.mono-debug-0.15.6
├── ms-vscode.powershell-1.4.1
├── ms-vscode.Theme-MarkdownKit-0.1.4
├── ms-vscode.Theme-MaterialKit-0.1.4
├── PeterJausovec.vscode-docker-0.0.16
├── robertohuertasm.vscode-icons-7.10.1
├── samverschueren.yo-0.9.3
├── Shan.code-settings-sync-2.8.1
├── wmaurer.join-lines-0.2.2
├── xabikos.javascriptsnippets-1.4.1
├── zgudino.editorconfig-vscode-snippet-0.2.0
└── zhuangtongfa.material-theme-2.8.9
```
