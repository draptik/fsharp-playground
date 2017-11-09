open System

let foo() =
    printfn "FOO"

foo()




[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
