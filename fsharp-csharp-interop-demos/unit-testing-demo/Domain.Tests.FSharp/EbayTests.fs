module EbayTests

open System
open FsUnit.Xunit
open Xunit
open Domain
open NHamcrest

[<Fact>]
let ``GetSearchResultFor returns correct result (using FsUnit)`` () =
    // Calling a C# static method (from a static class) from F#:
    Ebay.GetSearchResultsFor("bar") |> should equal "BAR"


[<Fact>]
let ``GetSearchResultFor returns correct result (not using FsUnit)`` () =
    Assert.That(Ebay.GetSearchResultsFor("bar"), Is.EqualTo("BAR"))
