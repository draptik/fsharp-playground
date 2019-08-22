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
    let v1 (unvalidatedUser1 : UnvalidatedUser) =
        let firstNameResult = FirstName.create unvalidatedUser1.FirstName
        let lastNameResult = LastName.create unvalidatedUser1.LastName
        let f0 = createValidUser unvalidatedUser1.Id // partial application
        let f1 = Result.map f0 firstNameResult // functor map
        let f2 = apply f1 lastNameResult // applicative apply
        match f2 with
        | Error err -> Error err
        | Ok f3 -> Ok (f3 unvalidatedUser1.Dob unvalidatedUser1.TwitterProfileUrl)
   
//    v1 unvalidatedUser
    
    let v2 (unvalidatedUser2 : UnvalidatedUser) =
        let firstNameResult = FirstName.create unvalidatedUser2.FirstName
        let lastNameResult = LastName.create unvalidatedUser2.LastName
        let f0 = createValidUser unvalidatedUser2.Id
        let f1 = Result.map f0 firstNameResult <*> lastNameResult // infix apply
        match f1 with
        | Error err -> Error err
        | Ok f3 -> Ok (f3 unvalidatedUser2.Dob unvalidatedUser2.TwitterProfileUrl)
   
//    v2 unvalidatedUser

    let v3 (unvalidatedUser3 : UnvalidatedUser) =
        let firstNameResult = FirstName.create unvalidatedUser3.FirstName
        let lastNameResult = LastName.create unvalidatedUser3.LastName
        let f0 = createValidUser unvalidatedUser3.Id
        let f1 = f0 <!> firstNameResult <*> lastNameResult // infix map & apply
        match f1 with
        | Error err -> Error err
        | Ok f3 -> Ok (f3 unvalidatedUser3.Dob unvalidatedUser3.TwitterProfileUrl)
   
    v3 unvalidatedUser
    
    