open FSharp.Data

// see https://fsharp.github.io/FSharp.Data/library/JsonProvider.html

type Person = JsonProvider<"people.json">

// Magic... This is type-safe!
let printPeople =
    let people = Person.GetSamples()
    for person in people do
        printf "%s " person.Name
        person.Age |> Option.iter (printf "(%d)")
        printfn ""
    
[<EntryPoint>]
let main argv =

    printPeople    

    0 // return an integer exit code
