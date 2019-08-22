module demo1.UserValidationTests

open Xunit

open demo1.ResultTestHelpers
open demo1.Domain

let homer : UnvalidatedUser = { Id = 42; FirstName = "Homer"; LastName = "Simpson"; Dob = None; TwitterProfileUrl = None }

[<Fact>]
let ``Validating a valid user`` () =
    homer |> validateUser |> isOk

[<Fact>]
let ``Validating an invalid user with missing first name`` () =
    {homer with FirstName = ""} |> validateUser |> isNotOk

[<Fact>]
let ``Validating an invalid user with missing first name has correct error message`` () =
    {homer with FirstName = ""}
    |> validateUser 
    |> hasCorrectErrorMessage ["FirstName must not be empty"]

[<Fact>]
let ``Validating an invalid user with missing last name has correct error message`` () =
    {homer with LastName = ""}
    |> validateUser 
    |> hasCorrectErrorMessage ["LastName must not be empty"]

[<Fact>]
let ``Validating an invalid user with missing first and last name has correct error message`` () =
    {homer with FirstName = ""; LastName = ""}
    |> validateUser 
    |> hasCorrectErrorMessage ["FirstName must not be empty"; "LastName must not be empty"]
