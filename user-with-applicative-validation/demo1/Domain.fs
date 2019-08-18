module demo1.Domain

open System
open FsUnit.Xunit
open Xunit

type NonEmptyString = private NonEmptyString of string

let create s =
    match String.IsNullOrWhiteSpace(s) with
    | true -> Error [ "String must not be empty" ]
    | false -> Ok(NonEmptyString s)

type UnvalidatedUser = {
    Id: int
    FirstName: string
    LastName: string
    Dob: DateTime option
    TwitterProfileUrl: string option
}

type ValidatedUser = {
    Id: int
    FirstName: NonEmptyString
    LastName: string
    Dob: DateTime option
    TwitterProfileUrl: string option
}

let format (user : UnvalidatedUser) =
    let fieldSeparator = " "
    let dob =
        match user.Dob with
        | Some x -> fieldSeparator + x.ToString("yyyy-MM-dd")
        | None -> String.Empty
    
    let twitter =
        match user.TwitterProfileUrl with
        | Some x -> fieldSeparator + x
        | None -> String.Empty
        
    sprintf "%s %s%s%s" user.FirstName user.LastName dob twitter 


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

//
//type AddressBook = {
//    Contacts: User list
//    
//    // TODO
//    // add new contact
//    // list all contacts
//    // remove contact
//    
//}
