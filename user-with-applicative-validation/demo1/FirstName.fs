module demo1.FirstName

open demo1.NonEmptyString

type FirstName = private FirstName of NonEmptyString

let create s =
    match NonEmptyString.create s with
    | Ok s -> Ok(FirstName s)
    | Error _ -> Error ["FirstName must not be empty"]
