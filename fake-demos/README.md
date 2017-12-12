# FAKE, F# Make

## Installation

### Windows

`choco install fake -pre`

### Linux

Download FAKE Portable directly from the homepage. Note: This requires a working .NET Core installation.

https://github.com/fsharp/FAKE/releases

-> `fake-dotnetcore-portable.zip`

## Hello World

FAKE version 5 has support for .NET Core.

Documentation is a bit sketchy at the moment... (the example `build.fsx` file linked from the Getting started section has more than 1k LOC).

Finally found this thread for creating a hello world example: https://github.com/fsharp/FAKE/issues/1675

`build.fsx`:
```
printfn "test"
```

- `fake run build.fsx`
