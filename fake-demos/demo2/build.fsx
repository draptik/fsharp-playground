(* -- Fake Dependencies paket.dependencies
file ./paket.dependencies
group netcorebuild
-- Fake Dependencies -- *)

#if !DOTNETCORE
#I "./packages/netcorebuild"
#r "NETStandard.Library.NETFramework/build/net461/lib/netstandard.dll"
#r "Fake.DotNet.Paket/lib/netstandard2.0/Fake.DotNet.Paket.dll"
#r "Fake.IO.FileSystem/lib/netstandard2.0/Fake.IO.FileSystem.dll"
#r "Fake.Core.Globbing/lib/netstandard2.0/Fake.Core.Globbing.dll"
#r "Fake.Core.String/lib/netstandard2.0/Fake.Core.String.dll"
#r "Fake.Core.Target/lib/netstandard2.0/Fake.Core.Target.dll"
#r "Fake.DotNet.Cli/lib/netstandard2.0/Fake.DotNet.Cli.dll"
#r "Fake.Core.ReleaseNotes/lib/netstandard2.0/Fake.Core.ReleaseNotes.dll"
#r "Fake.Core.Process/lib/netstandard2.0/Fake.Core.Process.dll"
#r "Fake.Core.Environment/lib/netstandard2.0/Fake.Core.Environment.dll"
#endif

open System
open System.IO
open System.Text.RegularExpressions
open Fake.Core.Globbing.Operators
open Fake.Core
open Fake.Core.Process
open Fake.Core.TargetOperators
open Fake.DotNet.Cli
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.DotNet
open Fake.Core.String


printfn "test_before targets"
Target.Create "Start" (fun _ -> ())

Target.Create "TestTarget" (fun _ ->
    printfn "Starting Build."
    Trace.traceFAKE "Some Info from FAKE"
    printfn "Ending Build."
)

"Start"
  ==> "TestTarget"

printfn "before run targets"

Target.RunOrDefault "TestTarget"