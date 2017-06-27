module Version4

open All

let RuleFor denominator definedResult = 
    fun (year) ->
        if IsDividableBy year denominator then
            (true, definedResult)
        else
            (false, false) 

let DefaultRule = fun (year) -> 
    (true, false)

let IsLeapYear year =

    let chainOfRules = [
        RuleFor 400 true; 
        RuleFor 100 false; 
        RuleFor 4 true; 
        DefaultRule;
        ]

    let (_, result) = 
        chainOfRules 
            |> List.map(fun rule -> rule year)
            |> List.filter(fun (doesRuleApply, _) -> doesRuleApply)
            |> List.head
    
    result