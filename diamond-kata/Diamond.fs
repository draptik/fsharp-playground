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

let makeUpperHalf distance =
    ['A'..(distance + ('A' |> int) |> char)] 
    |> List.map string
    |> List.mapi (fun index c -> dashes (distance - index) + c)
    |> List.mapi (fun index c -> c + dashes (index))
    |> List.map mirrorLine

let getDiamond letter =
    match letter with
    | "A" -> ["A"]
    | _ ->
        distanceFromA letter
        |> makeUpperHalf
        |> mirror
