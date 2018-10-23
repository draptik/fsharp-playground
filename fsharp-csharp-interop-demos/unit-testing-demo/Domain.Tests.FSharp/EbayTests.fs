module EbayTests

open System
open FsUnit.Xunit
open Xunit
open Domain

[<Fact>]
let ``GetSearchResultFor returns correct result`` () =
    // Calling a C# static method (from a static class) from F#:
    Ebay.GetSearchResultsFor("bar") |> should equal "BAR"

