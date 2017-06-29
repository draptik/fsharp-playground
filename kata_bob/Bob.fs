module Bob

open System

let endsWithQuestionMark (s:string) =
    s.EndsWith "?"

let hey statement =
    if endsWithQuestionMark statement
        then "Sure."
    elif statement = "Tom-ay-to, tom-aaaah-to." 
        then "Whatever."
    else    
        "Whoa, chill out!"