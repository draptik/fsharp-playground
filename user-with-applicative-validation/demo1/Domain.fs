module demo1.Domain

open System
open Xunit

type User = {
    Id: int
    FirstName: string
    LastName: string
    Dob: DateTime option
    TwitterProfileUrl: string option
}

let format user =
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

[<Fact>]
let ``Formatting user with minimal required info`` () =
    let user = { Id = 42; FirstName = "Homer"; LastName = "Simpson"; Dob = None; TwitterProfileUrl = None }
    let actual = format user
    Assert.Equal("Homer Simpson", actual)

[<Fact>]
let ``Formatting user with Date of Birth`` () =
    let user = { Id = 42; FirstName = "Homer"; LastName = "Simpson"; Dob = Some (new DateTime(1980, 1, 1)); TwitterProfileUrl = None }
    let actual = format user
    Assert.Equal("Homer Simpson 1980-01-01", actual)

[<Fact>]
let ``Formatting user with Twitter`` () =
    let user = { Id = 42; FirstName = "Homer"; LastName = "Simpson"; Dob = None; TwitterProfileUrl = Some "https://homer.simpson@twitter.com" }
    let actual = format user
    Assert.Equal("Homer Simpson https://homer.simpson@twitter.com", actual)

[<Fact>]
let ``Formatting user with Date of birth and Twitter`` () =
    let user = { Id = 42; FirstName = "Homer"; LastName = "Simpson"; Dob = Some (new DateTime(1980, 1, 1)); TwitterProfileUrl = Some "https://homer.simpson@twitter.com" }
    let actual = format user
    Assert.Equal("Homer Simpson 1980-01-01 https://homer.simpson@twitter.com", actual)

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
