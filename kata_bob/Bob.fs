module Bob

open System
open System.Text.RegularExpressions

let areAllWordsUpperCase s =
    let acronyms = ["OK"]
    let m = Regex.Match(s, "[A-Z]{2,}") in
        m.Success

let isYelling s =
    areAllWordsUpperCase s

let endsWithQuestionMark (s:string) =
    s.EndsWith "?"


let hey statement =
    if isYelling statement then "Whoa, chill out!"
    elif endsWithQuestionMark statement then "Sure."
    else "Whatever."