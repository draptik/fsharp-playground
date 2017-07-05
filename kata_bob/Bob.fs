module Bob

open System
open System.Text.RegularExpressions

let areAllWordsAcronyms words =
    let acronyms = ["OK"]
    Seq.forall (fun word -> List.contains word acronyms) words

let mapRegexMatchesToSeq groupCollection =
    groupCollection |> Seq.cast<Group> |> Seq.map (fun x -> x.Value)

(* TODO Replace this *)
let isAnyWordUpperCaseAndNotAcronym s =
    let m = Regex.Match(s, "[A-Z]{2,}") in
        if m.Success then
            let upperCaseWords = mapRegexMatchesToSeq m.Groups
            not (upperCaseWords |> areAllWordsAcronyms)
        else false

// let (|GetAllUpperCaseWords|_|) s =
//     let m = Regex.Match(s, "[A-Z]{2,}")
//     if m.Success then Some mapRegexMatchesToSeq else None


let (|IsYelling|_|) s =
    if isAnyWordUpperCaseAndNotAcronym s then Some IsYelling else None
// let (|IsYelling|_|) s =
//     match s with
//     | GetAllUpperCaseWords 
//         | areAllWordsAcronyms -> Some IsYelling
//         | _ -> None
//     | _ -> false


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