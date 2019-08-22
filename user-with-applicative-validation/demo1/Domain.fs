module demo1.Domain

open System
open demo1.ResultExtensions
open demo1.FirstName
open demo1.LastName

type UnvalidatedUser = {
    Id: int
    FirstName: string
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

type ValidatedUser = {
    Id: int
    FirstName: FirstName
    LastName: LastName
    Dob: DateTime option
    TwitterProfileUrl: string option
}

let createValidUser id firstName lastName dob twitter =
    { Id = id; FirstName = firstName; LastName = lastName; Dob = dob; TwitterProfileUrl = twitter }
    
let validateUser (unvalidatedUser : UnvalidatedUser) : Result<ValidatedUser, string list> =
    let v1 (u : UnvalidatedUser) =
        let firstNameResult = FirstName.create u.FirstName
        let lastNameResult = LastName.create u.LastName
        let f0 = createValidUser u.Id // partial application
        let mapResult = Result.map f0 firstNameResult // functor map
        let validationResult = apply mapResult lastNameResult // applicative apply
        match validationResult with
        | Error err -> Error err
        | Ok f3 -> Ok (f3 u.Dob u.TwitterProfileUrl)
   
//    v1 unvalidatedUser
    
    let v2 (u : UnvalidatedUser) =
        let firstNameResult = FirstName.create u.FirstName
        let lastNameResult = LastName.create u.LastName
        let f0 = createValidUser u.Id
        let validationResult = Result.map f0 firstNameResult <*> lastNameResult // infix apply
        match validationResult with
        | Error err -> Error err
        | Ok f3 -> Ok (f3 u.Dob u.TwitterProfileUrl)
   
//    v2 unvalidatedUser

    let v3 (u : UnvalidatedUser) =
        let firstNameResult = FirstName.create u.FirstName
        let lastNameResult = LastName.create u.LastName
        let f0 = createValidUser u.Id
        let validationResult = f0 <!> firstNameResult <*> lastNameResult // infix map & apply
        match validationResult with
        | Error err -> Error err
        | Ok f3 -> Ok (f3 u.Dob u.TwitterProfileUrl)
   
    v3 unvalidatedUser
    
    