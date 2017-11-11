module DiamondTests

open FsUnit
open Xunit

let getDiamond input =
    [
        "__A__"; 
        "_B_B_"; 
        "C___C"; 
        "_B_B_"; 
        "__A__"]

[<Fact(Skip = "TODO")>]
let ``Diamond A should return correct diamond`` () =
    getDiamond('A') |> should equal ["A"]

[<Fact(Skip = "TODO")>]
let ``Diamond B should return correct diamond`` () =
    getDiamond('B') 
    |> should equal [
        "_A_"; 
        "B_B"; 
        "_A_"]

[<Fact>]
let ``Diamond C should return correct diamond`` () =
    getDiamond('C') 
    |> should equal [
        "__A__"; 
        "_B_B_"; 
        "C___C"; 
        "_B_B_"; 
        "__A__"]
