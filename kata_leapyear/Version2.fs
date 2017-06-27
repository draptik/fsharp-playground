module Version2

open All

let IsLeapYear year =
    match year with
    | DividableBy 400 -> true
    | DividableBy 100 -> false
    | DividableBy 4 -> true
    | _ -> false
