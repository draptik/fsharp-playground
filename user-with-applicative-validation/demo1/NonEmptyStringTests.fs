module demo1.NonEmptyStringTests

open System
open Xunit
open demo1.ResultTestHelpers

[<Fact>]
let ``Invalid string has correct error message`` () =
    let invalidResult = NonEmptyString.create String.Empty
    invalidResult |> hasCorrectErrorMessage "String must not be empty"

[<Fact>]
let ``Valid string has correct content`` () =
    let validResult = NonEmptyString.create "valid"
    validResult |> isOkAndEquals NonEmptyString.get "valid"
