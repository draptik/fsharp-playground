module demo1.ResultExtensions

// infix map
let (<!>) = Result.map

// Applicative validation =====================================================

let apply (f : Result<'a -> 'b, 'c list>) (a : Result<'a, 'c list>) : Result<'b, 'c list> =
    match f, a with
    | Ok f, Ok a -> Ok(f a)
    | Error f, Error a -> Error <| f @ a
    | Error f, _ -> Error f
    | _, Error a -> Error a

let (<*>) = apply
    
let lift a = Ok a
