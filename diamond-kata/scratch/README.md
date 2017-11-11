# Initial setup

- `dotnet new xunit -lang f# -o scratch`
- `cd scratch`
- `dotnet add package fsunit`
- `dotnet add package fsunit.xunit`
- `dotnet restore`

## Installing "dotnet watch" for continuous automated tests

Add the following snippet to the `*.fsproj` file:

``` xml
<ItemGroup>
    <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="2.0.0" />
</ItemGroup>
```

The complete `fsproj` now looks like this:

``` xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
    <IsPackable>false</IsPackable>
  </PropertyGroup>
  <ItemGroup>
    <Compile Include="Tests.fs" />
    <Compile Include="Program.fs" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="fsunit" Version="3.0.0" />
    <PackageReference Include="fsunit.xunit" Version="3.0.0" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.3.0-preview-20170628-02" />
    <PackageReference Include="xunit" Version="2.2.0" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.2.0" />
  </ItemGroup>
  <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="2.0.0" />
  </ItemGroup>
</Project>
```

# Running tests

## manually, from the command line

- `dotnet test`

## automated, from the command line

- `dotnet watch test`
