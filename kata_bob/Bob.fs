module Bob

open System

let areAllWordsUpperCase (s:string) =
    s = "WHAT THE HELL WERE YOU THINKING?"

let endsWithQuestionMark (s:string) =
    s.EndsWith "?"


let hey statement =
    if areAllWordsUpperCase statement
        then "Whoa, chill out!"
    elif endsWithQuestionMark statement
        then "Sure."
    elif statement = "Tom-ay-to, tom-aaaah-to." 
        then "Whatever."
    else    
        "Whoa, chill out!"