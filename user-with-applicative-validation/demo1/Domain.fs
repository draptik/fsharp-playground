module demo1.Domain

open System
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
    LastName: string
    Dob: DateTime option
    TwitterProfileUrl: string option
}

let validateUser (unvalidatedUser : UnvalidatedUser) =
    match NonEmptyString.create unvalidatedUser.FirstName with
    | Ok firstName -> Ok {
        Id = unvalidatedUser.Id;
        FirstName = firstName;
        LastName = unvalidatedUser.LastName;
        Dob = unvalidatedUser.Dob;
        TwitterProfileUrl = unvalidatedUser.TwitterProfileUrl
        }
    | Error msg -> Error msg 
