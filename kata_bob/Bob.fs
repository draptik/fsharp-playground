module Bob

open System
open System.Text.RegularExpressions

let (|UpperCase|) (x:string) = x.ToUpper()

let (|Match|_|) pattern input =
    let m = Regex.Match(input, pattern) in
    if m.Success then Some (List.append [ for g in m.Groups -> g.Value ]) 
    else None


let rec fib n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> fib (n - 1) + fib (n - 2)

let (|AtLeast|_|) n score =
    if score >= n then Some AtLeast else None

let gradeMatch g =
    match g with
    | AtLeast 90 -> "A"
    | AtLeast 80 -> "B"
    | AtLeast 70 -> "C"
    | AtLeast 60 -> "D"
    | _ -> "F"

let grade =
    function
    | AtLeast 90 -> "A"
    | AtLeast 80 -> "B"
    | AtLeast 70 -> "C"
    | AtLeast 60 -> "D"
    | _ -> "F"


let getMatchValue (m: Match) = m.Value

let matchInput s =
    let r = Regex("[A-Z]{2,}")
    let m = r.Match s in
        if m.Success then
            printfn "printline debugging: m.Groups = %A" m.Groups
            m.Groups 
            |> Seq.cast 
            |> Seq.map getMatchValue 
            |> Some
        else    
            None

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