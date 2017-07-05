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

let (|IsYelling|_|) s =
    if areAllWordsUpperCaseAndNotAcronyms s then Some IsYelling else None

let (|EndsWithQuestionMark|_|) (s:string) =
    if s.EndsWith "?" then Some EndsWithQuestionMark else None

let (|IsMeaningless|_|) (s:string) = 
    if String.IsNullOrWhiteSpace(s) then Some IsMeaningless else None

let hey statement =
    match statement with
    | IsYelling -> "Whoa, chill out!"
    | EndsWithQuestionMark -> "Sure."
    | IsMeaningless -> "Fine. Be that way!"
    | _ -> "Whatever."