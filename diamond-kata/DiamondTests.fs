module DiamondTests

open FsUnit
open Xunit
open Diamond

[<Fact>]
let ``generate a diamond for A`` () =
    getDiamond("A") |> should equal ["A"]

[<Fact>]
let ``generate a diamond for B`` () =
    getDiamond("B") 
    |> should equal [
        "_A_"; 
        "B_B"; 
        "_A_"]

[<Fact>]
let ``generate a diamond for C`` () =
    getDiamond("C") 
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
    mirror([ "A"; "B"; "C" ])
    |> should equal [ "A"; "B"; "C"; "B"; "A"]        

    mirror([ "A"; "B" ])
    |> should equal [ "A"; "B"; "A"]                

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
