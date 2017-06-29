module Bob

open System

// "s" can't be invered!
// In this case we have to provide the type using the "(varName: type)" syntax
// As C# developer I know that the .NET framework provides the extension method "foo".EndsWith("bla")
//
// This does not work
//  let endsWithQuestionMark s =
//      s.EndsWith "?"
//
// In the above example the F# compiler cannot "guess" the input type (string).
// So we have to tell the compiler that this function only accepts strings using "(s:string)"
//
let endsWithQuestionMark (s:string) =
    s.EndsWith "?"

let hey statement =

    if endsWithQuestionMark statement
        then "Sure."
    elif statement = "Tom-ay-to, tom-aaaah-to." 
        then "Whatever."
    elif endsWithQuestionMark statement
        then "Sure."
    else    
        "Whoa, chill out!"