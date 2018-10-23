module CustomerTests

open FsUnit.Xunit
open System
open Xunit

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``FsUnit works`` () =
    true |> should equal true
