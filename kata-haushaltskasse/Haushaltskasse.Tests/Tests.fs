module Tests

open System
open Xunit
open FsUnit.Xunit

module Domain =

    type Betrag = private Betrag of int

    module Betrag =
        let create (number: int) =
            match number with
            | n when (n < 0) -> Error "Betrag darf nicht negativ sein!"
            | n when (n > 1000) -> Error "Betraege groesser als 1000 sind nicht erlaubt!"
            | _ -> Ok number
        
        let value (Betrag int) = int
open Domain

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``FsUnit Smoke Test`` () =
    1 + 1 |> should equal 2

[<Fact>]
let ``Betrag kleiner 0 gibt Fehler`` () =
    let betrag = Domain.Betrag.create(10) // geht das auch einfacher?
    betrag |> should equal Ok 10 // was ist hier falsch?
    Assert.True(true)    
