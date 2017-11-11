module DiamondTests

open FsUnit
open Xunit

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

let dashes (num: int) =
    String.replicate num "_"

let distanceFromA (input: string) = 
    let c = input.[0]
    (c |> int) - ('A' |> int)

let generateCharacterSequence (input: string) : string list = 
    ['A'..(distanceFromA input + ('A' |> int) |> char)] 
    |> List.map string

let makeLine index character =
    dashes ((distanceFromA "C") - index) + character + dashes (index)

let getDiamond input =
    
    let upperLeft = 
        generateCharacterSequence "C"
        |> List.mapi makeLine

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

[<Fact>]
let ``generate expected number of dashes`` () =
    dashes 2 |> should equal "__"
    dashes 4 |> should equal "____"

[<Fact>]
let ``calculate the distance from A`` () =
    distanceFromA "A" |> should equal 0
    distanceFromA "C" |> should equal 2
    distanceFromA "Z" |> should equal 25

[<Fact>]
let ``generate a sequence of characters`` () =
    generateCharacterSequence "A" |> should equal [ "A" ]
    generateCharacterSequence "C" |> should equal [ "A"; "B"; "C" ]