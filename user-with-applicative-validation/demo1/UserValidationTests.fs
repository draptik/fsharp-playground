module demo1.UserValidationTests

open Xunit
open demo1.ResultTestHelpers
open demo1.Domain

let homer : UnvalidatedUser = { Id = 42; FirstName = "Homer"; LastName = "Simpson"; Dob = None; TwitterProfileUrl = None }

[<Fact>]
let ``Validating unvalidated but valid user`` () =
    homer |> validateUser |> isOk

[<Fact>]
let ``Validating unvalidated but invalid user`` () =
    {homer with FirstName = ""} |> validateUser |> isNotOk
