module demo1.Domain

open System
open demo1.ResultExtensions
open demo1.NonEmptyString

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
    FirstName: NonEmptyString
    LastName: NonEmptyString
    Dob: DateTime option
    TwitterProfileUrl: string option
}

let createValidUser id firstName lastName dob twitter =
    { Id = id; FirstName = firstName; LastName = lastName; Dob = dob; TwitterProfileUrl = twitter }
    
let validateUser (unvalidatedUser : UnvalidatedUser) : Result<ValidatedUser, string list> =
    let firstNameResult = NonEmptyString.create unvalidatedUser.FirstName
    let lastNameResult = NonEmptyString.create unvalidatedUser.LastName
    let f0 = createValidUser unvalidatedUser.Id
    let f1 = Result.map f0 firstNameResult
    let f2 = apply f1 lastNameResult
    match f2 with
    | Error err -> Error err
    | Ok f3 -> Ok (f3 unvalidatedUser.Dob unvalidatedUser.TwitterProfileUrl)
    
