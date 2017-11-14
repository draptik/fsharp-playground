module Diamond

let mirror (entries: string list) =
    let mirroredEntries =
        entries.[..(entries.Length - 2)]
        |> List.rev

    List.append entries mirroredEntries

let mirrorLine (line: string) =
    line
    |> Seq.map string
    |> Seq.toList
    |> mirror
    |> String.concat ""

let dashes num =
    String.replicate num "_"

let distanceFromA (input: string) = 
    let c = input.[0]
    (c |> int) - ('A' |> int)

let makeUpperHalf distance =
    ['A'..(distance + ('A' |> int) |> char)] 
    |> List.map string
    |> List.mapi (fun index firstHalf -> dashes (distance - index) + firstHalf)
    |> List.mapi (fun index secondHalf -> secondHalf + dashes (index))
    |> List.map mirrorLine

let getDiamond letter =
    match letter with
    | "A" -> ["A"]
    | _ ->
        distanceFromA letter
        |> makeUpperHalf
        |> mirror
