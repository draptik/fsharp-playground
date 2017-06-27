module Version3

open All

let IsLeapYear year =
    
    let rules = [ (400,true); (100,false); (4,true); ]
    
    let f = fun (denominator, _) -> IsDividableBy year denominator
    
    let option = 
        rules |> List.tryFind(f)
    if option.IsSome then
        let (_, result) = Option.get option
        result
    else 
        false
