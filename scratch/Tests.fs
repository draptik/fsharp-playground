module Tests

open System
open FsUnit.Xunit
open Xunit
open FsUnit.TopLevelOperators

[<Fact>]
let ``FsUnit Framework test`` () =
    true |> should equal true

[<Fact>]
let ``10 should be greater than 9`` () =
    10 |> should greaterThan 9