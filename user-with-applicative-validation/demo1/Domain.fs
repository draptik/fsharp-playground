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
   
//    v3 unvalidatedUser

    let v4 (u : UnvalidatedUser) =
        let firstNameResult = FirstName.create u.FirstName
        let lastNameResult = LastName.create u.LastName
        
        let validationResult = (Ok (createValidUser u.Id))
                               <*> firstNameResult
                               <*> lastNameResult
                               <*> (Ok u.Dob)
                               <*> (Ok u.TwitterProfileUrl)
        validationResult
   
//    v4 unvalidatedUser

    let v5 (u : UnvalidatedUser) =
        let firstNameResult = FirstName.create u.FirstName
        let lastNameResult = LastName.create u.LastName
        
        let x1 = apply (Ok (createValidUser u.Id)) firstNameResult
        let x2 = apply x1 lastNameResult
        let x3 = apply x2 (Ok u.Dob)
        let validationResult = apply x3 (Ok u.TwitterProfileUrl)
        validationResult
   
//    v5 unvalidatedUser
    
    let v6 (u : UnvalidatedUser) =
        let firstNameResult = FirstName.create u.FirstName
        let lastNameResult = LastName.create u.LastName
        
        let flip f a b = f b a
            
        let x1 = apply (Ok (createValidUser u.Id)) firstNameResult
        let x2 = flip apply lastNameResult x1
        let x3 = flip apply (Ok u.Dob) x2
        let validationResult = flip apply (Ok u.TwitterProfileUrl) x3
        validationResult
   
//    v6 unvalidatedUser
    
    let v7 (u : UnvalidatedUser) =
        let firstNameResult = FirstName.create u.FirstName
        let lastNameResult = LastName.create u.LastName
        
        let flip f a b = f b a
            
        let validationResult =
            apply (Ok (createValidUser u.Id)) firstNameResult
            |> flip apply lastNameResult
            |> flip apply (Ok u.Dob)
            |> flip apply (Ok u.TwitterProfileUrl)

        validationResult
   
    v7 unvalidatedUser
    