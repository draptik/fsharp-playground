module Diamond

let mirror (entries: string list) =
    let mirroredEntries =
        entries.[..(entries.Length - 2)]
        |> List.rev

    List.append entries mirroredEntries

let mirrorLine (line: string) =

    line
    |> (fun s -> [for c in s -> c])
    |> Seq.map (fun x -> x.ToString()) 
    |> Seq.toList
    |> mirror
    |> String.concat ""

let dashes (num: int) =
    String.replicate num "_"

let distanceFromA (input: string) = 
    let c = input.[0]
    (c |> int) - ('A' |> int)

let generateCharacterSequence offsetFromA = 
    ['A'..(offsetFromA + ('A' |> int) |> char)] 
    |> List.map string

// let makeLine index character =
//     dashes ((distanceFromA "C") - index) + character + dashes (index)

let makeUpperLeft numberOfCharsOffsetFromA : string list =
    generateCharacterSequence numberOfCharsOffsetFromA
    |> List.mapi (fun index currentChar ->
        dashes (numberOfCharsOffsetFromA - index) + currentChar + dashes (index))

let makeUpperHalf distance =
    makeUpperLeft distance
    |> List.map mirrorLine

let getDiamond input =
    
    distanceFromA input
    |> makeUpperHalf
    |> mirror

