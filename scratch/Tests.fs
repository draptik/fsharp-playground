module Tests

open System
open FsUnit.Xunit
open Xunit

[<Fact>]
let ``FsUnit Framework test`` () =
    true |> should equal true

