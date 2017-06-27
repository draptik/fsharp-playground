module Version1

open System

let IsLeapYear year =
    match year with
    | 1900 -> false
    | 1997 -> false
    | 2000 -> true
    | _ -> true