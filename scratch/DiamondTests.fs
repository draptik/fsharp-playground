module DiamondTests

open FsUnit
open Xunit
open System

let mirror (entries: string list) =
    let mirroredEntries =
        entries.[..(entries.Length - 2)]
        |> List.rev

    List.append entries mirroredEntries

let mirrorLine (line: string) =

    line
    |> (fun s -> [for c in s -> c])
    |> Seq.map (fun x -> x.ToString()) 
    |> Seq.toList
    |> mirror
    |> String.concat ""

let getDiamond input =
    let upperLeft = 
        [ "__A"; 
          "_B_"; 
          "C__"]

    let upperHalf = 
        upperLeft
        |> List.map mirrorLine
    
    mirror(upperHalf)

[<Fact(Skip = "TODO")>]
let ``generate a diamond for A`` () =
    getDiamond('A') |> should equal ["A"]

[<Fact(Skip = "TODO")>]
let ``generate a diamond for B`` () =
    getDiamond('B') 
    |> should equal [
        "_A_"; 
        "B_B"; 
        "_A_"]

[<Fact>]
let ``generate a diamond for C`` () =
    getDiamond('C') 
    |> should equal [
        "__A__"; 
        "_B_B_"; 
        "C___C"; 
        "_B_B_"; 
        "__A__"]

[<Fact>]
let ``mirror the upper half`` () =
    mirror(
        [
        "__A__"; 
        "_B_B_"; 
        "C___C"
        ])
    |> should equal [
        "__A__"; 
        "_B_B_"; 
        "C___C"; 
        "_B_B_"; 
        "__A__"]

[<Fact>]
let ``mirror the given entries`` () =
    mirror(
        [
        "A"; 
        "B"; 
        "C"
        ])
    |> should equal [
        "A"; 
        "B"; 
        "C"; 
        "B"; 
        "A"]        

    mirror(
        [
        "A"; 
        "B"
        ])
    |> should equal [
        "A"; 
        "B"; 
        "A"]                

[<Fact>]
let ``mirror the given line`` () =
    mirrorLine "__A"    |> should equal "__A__"
    mirrorLine "FSharp" |> should equal "FSharprahSF"
