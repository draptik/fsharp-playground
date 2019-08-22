module demo1.LastName

open demo1.NonEmptyString

type LastName = private LastName of NonEmptyString

let create s =
    match NonEmptyString.create s with
    | Ok s -> Ok(LastName s)
    | Error _ -> Error ["LastName must not be empty"]
