module All

open System

let IsDividableBy number denominator =
    number % denominator = 0

let (|DividableBy|_|) denominator year = 
    if IsDividableBy year denominator then Some DividableBy 
    else None