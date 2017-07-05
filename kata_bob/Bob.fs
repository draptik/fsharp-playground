module Bob

open System
open System.Text.RegularExpressions

let areAllWordsUpperCaseAndNotAcronyms s =
    let acronyms = ["OK"; "SOLID"]
    let m = Regex.Match(s, "[A-Z]{2,}") in
        if m.Success then
            let allMatchesAreAcronyms =
                m.Groups
                |> Seq.cast<Group>
                |> Seq.map (fun x -> x.Value)
                |> Seq.forall (fun x -> List.contains x acronyms)
            not allMatchesAreAcronyms
        else false

let isYelling s =
    areAllWordsUpperCaseAndNotAcronyms s

let endsWithQuestionMark (s:string) =
    s.EndsWith "?"

let isMeaningless (s:string) =
    String.IsNullOrWhiteSpace(s)

let hey statement =
    if isYelling statement then "Whoa, chill out!"
    elif endsWithQuestionMark statement then "Sure."
    elif isMeaningless statement then "Fine. Be that way!"
    else "Whatever."