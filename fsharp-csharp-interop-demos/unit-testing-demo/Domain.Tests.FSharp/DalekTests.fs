module DalekTests

open System
open FsUnit.Xunit
open Xunit
open Domain

[<Fact>]
let ``Dalek creation via ctor returns valid result`` () =
    // Calling a C# Ctor with nullable props from F#:
    let dalek = new Dalek(Nullable 1, Nullable 10)

    dalek.Id |> should equal 1
    dalek.Power |> should equal 10

[<Fact>]
let ``Dalek creation via props returns valid result`` () =
    // Using C# object initializer (with nullable props) syntax from F#:
    let dalek = new Dalek(Id = Nullable 1, Power = Nullable 10)

    dalek.Id |> should equal 1
    dalek.Power |> should equal 10
