module Tests

open System
open Xunit
open FsUnit.Xunit

module Domain =

    type Betrag = private Betrag of int

    module Betrag =
        let create (number: int) =
            match number with
            | n when (n < 0) -> failwith "Betrag darf nicht negativ sein!"
            | n when (n > 1000) -> failwith "Betraege groesser als 1000 sind nicht erlaubt!"
            | _ -> number
        
        let value (Betrag int) = int

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``FsUnit Smoke Test`` () =
    1 + 1 |> should equal 2

[<Fact>]
let ``Betrag kann nach Erstellung abgerufen werden`` () =
    let betrag = Domain.Betrag.create(10) // geht das auch einfacher?
    betrag |> should equal 10

[<Fact>]
let ``Betrag schmeisst Fehler, wenn kleiner 0`` () =
    Domain.Betrag.create(-1) |> shouldFail
