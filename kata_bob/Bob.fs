module Bob

open System
open System.Text.RegularExpressions

let isAnyWordUpperCaseAndNotAcronym s =
    let acronyms = ["OK"]
    let m = Regex.Match(s, "[A-Z]{2,}") in
        if m.Success then
            let allMatchesAreAcronyms =
                m.Groups
                |> Seq.cast<Group>
                |> Seq.map (fun x -> x.Value) (* 'map' corresponds to 'Select' in C# *)
                |> Seq.forall (fun x -> List.contains x acronyms) (* 'forall' corresponds to 'All' in C#. Returns true if ALL uppercase words are acronyms *)
            not allMatchesAreAcronyms
        else false

let (|IsYelling|_|) s =
    if isAnyWordUpperCaseAndNotAcronym s then Some IsYelling else None

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