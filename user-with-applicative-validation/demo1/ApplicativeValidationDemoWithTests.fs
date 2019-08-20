module demo1.ApplicativeValidationDemoWithTests

open System
open FsUnit.Xunit
open Xunit

// Adapter from https://fsharpforfunandprofit.com/posts/elevated-world-3/#validation
// (using built-in Result type provided by F#)

type CustomerId = CustomerId of int
type EmailAddress = EmailAddress of string

let createCustomerId id =
    if id > 0 then
        Ok (CustomerId id)
    else
        Error ["CustomerId must be positive"]

let createEmailAddress str =
    if String.IsNullOrEmpty(str) then
        Error ["Email must not be empty"]
    elif str.Contains("@") then
        Ok (EmailAddress str)
    else
        Error ["Email must contain @-sign"]

type Customer = {
    id: CustomerId
    email: EmailAddress
}

let createCustomer customerId email =
    { id=customerId;  email=email }


let map f xResult =
        match xResult with
        | Ok x -> Ok (f x)
        | Error errs -> Error errs

let (<!>) = map            

let apply fResult xResult =
        match fResult, xResult with
        | Ok f, Ok x ->
            Ok (f x)
        | Error errs, Ok _ ->
            Error errs
        | Ok _, Error errs ->
            Error errs
        | Error errs1, Error errs2 ->
            // concat both lists of errors
            Error (List.concat [errs1; errs2])

let (<*>) = apply

let createCustomerResultUsingApplicativeValidationMapApply id email =
    let idResult = createCustomerId id
    let emailResult = createEmailAddress email
    let createCustomerFunctionWithIdResult = map createCustomer idResult
    let result = apply createCustomerFunctionWithIdResult emailResult
    result
    
let createCustomerResultUsingApplicativeValidationMapInfixApply id email =
    let idResult = createCustomerId id
    let emailResult = createEmailAddress email
    let result = map createCustomer idResult <*> emailResult
    result
    
let createCustomerResultUsingApplicativeValidationInfix id email =
    let idResult = createCustomerId id
    let emailResult = createEmailAddress email
    let result = createCustomer <!> idResult <*> emailResult
    result


[<Fact>]
let ``Invalid customer creation returns correct error (map/apply)`` () =
    let actual = createCustomerResultUsingApplicativeValidationMapApply 0 "invalid"
    match actual with
    | Ok _ -> false |> should equal true
    | Error msg -> msg |> should equal ["CustomerId must be positive"; "Email must contain @-sign"]

[<Fact>]
let ``Invalid customer creation returns correct error (map w/ Infix apply)`` () =
    let actual = createCustomerResultUsingApplicativeValidationMapInfixApply 0 "invalid"
    match actual with
    | Ok _ -> false |> should equal true
    | Error msg -> msg |> should equal ["CustomerId must be positive"; "Email must contain @-sign"]

[<Fact>]
let ``Invalid customer creation returns correct error (all Infix)`` () =
    let actual = createCustomerResultUsingApplicativeValidationInfix 0 "invalid"
    match actual with
    | Ok _ -> false |> should equal true
    | Error msg -> msg |> should equal ["CustomerId must be positive"; "Email must contain @-sign"]
    