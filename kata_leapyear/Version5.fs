module Version5

open All

type Rule = | Applies | DoesNotApply

type Y = | IsLeapYear | IsNonLeapYear

let IsLeapYear givenYear =

    let ruleFor denominator definedResult = 
        fun (year) ->
            if IsDividableBy year denominator then
                (Rule.Applies, definedResult)
            else
                (Rule.DoesNotApply, Y.IsNonLeapYear) 

    let defaultRule = fun (year) -> (Rule.Applies, Y.IsNonLeapYear)

    let chainOfRules = [
        ruleFor 400 Y.IsLeapYear; 
        ruleFor 100 Y.IsNonLeapYear; 
        ruleFor 4 Y.IsLeapYear; 
        defaultRule;
        ]

    let (_, year) = 
        chainOfRules
            |> List.map(fun rule -> rule givenYear)
            |> List.filter(fun (doesRuleApply, _) -> doesRuleApply = Rule.Applies)
            |> List.head
            
    year = Y.IsLeapYear