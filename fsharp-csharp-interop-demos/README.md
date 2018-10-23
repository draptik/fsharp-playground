# F# C# Interop Demos

First Goal: How to introduce F# into a C# project using F# unit tests.

## Project Setup

```
mkdir unit-testing-demo
cd unit-testing-demo

dotnet new sln -n Demo

dotnet new classlib -o Domain
dotnet new xunit -o Domain.Tests.CSharp
dotnet new xunit -lang f# -o Domain.Tests.FSharp

dotnet sln add Domain/Domain.csproj
dotnet sln add Domain.Tests.CSharp/Domain.Tests.CSharp.csproj
dotnet sln add Domain.Tests.FSharp/Domain.Tests.FSharp.fsproj

cd Domain.Tests.CSharp/
dotnet add reference ../Domain/Domain.csproj
cd ..
cd Domain.Tests.FSharp/
dotnet add reference ../Domain/Domain.csproj
cd ..

dotnet test
```

## Tech Stack

```
dotnet --info
.NET Core SDK (reflecting any global.json):
 Version:   2.1.403
 Commit:    04e15494b6

Runtime Environment:
 OS Name:     arch
 OS Version:  
 OS Platform: Linux
 RID:         arch-x64
 Base Path:   /opt/dotnet/sdk/2.1.403/

Host (useful for support):
  Version: 2.1.5
  Commit:  290303f510

.NET Core SDKs installed:
  2.1.3 [/opt/dotnet/sdk]
  2.1.403 [/opt/dotnet/sdk]

.NET Core runtimes installed:
  Microsoft.NETCore.App 2.1.5 [/opt/dotnet/shared/Microsoft.NETCore.App]
```
