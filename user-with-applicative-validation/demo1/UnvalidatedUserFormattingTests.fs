module Tests

open System
open FsUnit.Xunit
open Xunit
open demo1.Domain

let homer : UnvalidatedUser = { Id = 42; FirstName = "Homer"; LastName = "Simpson"; Dob = None; TwitterProfileUrl = None }

[<Fact>]
let ``Formatting user with minimal required info`` () =
    homer
    |> format
    |> should equal "Homer Simpson"

[<Fact>]
let ``Formatting user with Date of Birth`` () =
    { homer with Dob = Some (new DateTime(1980, 1, 1)) }
    |> format
    |> should equal "Homer Simpson 1980-01-01"

[<Fact>]
let ``Formatting user with Twitter`` () =
    { homer with TwitterProfileUrl = Some "https://homer.simpson@twitter.com" }
    |> format
    |> should equal "Homer Simpson https://homer.simpson@twitter.com"

[<Fact>]
let ``Formatting user with Date of birth and Twitter`` () =
    { homer with Dob = Some (new DateTime(1980, 1, 1)); TwitterProfileUrl = Some "https://homer.simpson@twitter.com" }
    |> format
    |> should equal "Homer Simpson 1980-01-01 https://homer.simpson@twitter.com"
