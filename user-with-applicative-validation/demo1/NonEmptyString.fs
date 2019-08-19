module demo1.NonEmptyString

open System

type NonEmptyString = private NonEmptyString of string

let create s =
    match String.IsNullOrWhiteSpace(s) with
    | true -> Error "String must not be empty"
    | false -> Ok(NonEmptyString s)
