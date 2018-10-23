module CustomerTests

open System
open FsUnit.Xunit
open Xunit
open Domain

[<Fact>]
let ``Customer creation via ctor returns valid customer`` () =
    // Calling a C# Ctor from F#:
    let customer = new Customer(1, "fn", "ln")

    customer.Id |> should equal 1
    customer.FirstName |> should equal "fn"
    customer.LastName |> should equal "ln"

[<Fact>]
let ``Customer creation via props returns valid customer`` () =
    // Using C# object initializer syntax from F#:
    let customer = new Customer(Id = 1, FirstName = "fn", LastName = "ln")

    customer.Id |> should equal 1
    customer.FirstName |> should equal "fn"
    customer.LastName |> should equal "ln"
