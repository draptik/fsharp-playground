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

let dashes num =
    String.replicate num "_"

let distanceFromA (input: string) = 
    let c = input.[0]
    (c |> int) - ('A' |> int)

let generateCharacterSequence offsetFromA = 
    ['A'..(offsetFromA + ('A' |> int) |> char)] 
    |> List.map string

let makeUpperLeft posInAlphabet : string list =
    generateCharacterSequence posInAlphabet
    |> List.mapi (fun index c -> dashes (posInAlphabet - index) + c)
    |> List.mapi (fun index c -> c + dashes (index))

let makeUpperHalf distance =
    makeUpperLeft distance
    |> List.map mirrorLine

let getDiamond letter =
    if letter = "A" then ["A"]
    else
        distanceFromA letter
        |> makeUpperHalf
        |> mirror
