module Diamond

let mirror (entries: string list) =
    entries
    @ (entries |> List.rev |> List.tail)

let mirrorLine (line: string) =
    line
    |> Seq.map string
    |> Seq.toList
    |> mirror
    |> String.concat ""

let dashes num =
    String.replicate num "_"

let distanceFromA (input: string) = 
    (Seq.head input |> int) - ('A' |> int)

let makeUpperHalf distance =
    ['A'..(distance + ('A' |> int) |> char)] 
    |> List.map string
    |> List.mapi (fun index firstHalf -> dashes (distance - index) + firstHalf)
    |> List.mapi (fun index secondHalf -> secondHalf + dashes (index))
    |> List.map mirrorLine

let getDiamond letter =
    distanceFromA letter
    |> makeUpperHalf
    |> mirror
