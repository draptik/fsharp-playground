module Bob

open System
open System.Text.RegularExpressions

let areAllWordsAcronyms words =
    let acronyms = ["OK"]
    Seq.forall (fun word -> List.contains word acronyms) words

let isAnyWordUpperCaseAndNotAcronym s =
    let m = Regex.Match(s, "[A-Z]{2,}") in
        if m.Success then
            let allMatchesAreAcronyms =
                m.Groups
                |> Seq.cast<Group>
                |> Seq.map (fun x -> x.Value) (* 'map' corresponds to 'Select' in C# *)
                |> areAllWordsAcronyms
            not allMatchesAreAcronyms
        else false

let (|GetAllUpperCaseWords|_|) s =
    let mapRegexMatchesToSeq groupCollection =
        groupCollection |> Seq.cast<Group> |> Seq.map (fun x -> x.Value)

    let m = Regex.Match(s, "[A-Z]{2,}")

    if m.Success then Some mapRegexMatchesToSeq
    else None
        

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