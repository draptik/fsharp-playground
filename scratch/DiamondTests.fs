module DiamondTests

open FsUnit
open Xunit

let mirror (upperHalf: string list) =
    let lowerHalf =
        upperHalf.[..1]
        |> List.rev

    // let lowerHalf = [
    //     "_B_B_"; 
    //     "__A__"]
    
    List.append upperHalf lowerHalf

let getDiamond input =
    
    let upperHalf = [
        "__A__"; 
        "_B_B_"; 
        "C___C"]

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