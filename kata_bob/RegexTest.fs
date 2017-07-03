module RegexTest

open System.Text.RegularExpressions

open Xunit

let getMatchValue (m: Match) = m.Value

let getNumberOfMatches r s =
    let regex = Regex(r)
    let allMatches = regex.Matches s
    allMatches.Count


[<Fact>]
let ``given input AA should return 1 match for regex`` () =
    Assert.Equal(1, getNumberOfMatches "[A-Z]{2,}" "AA")

[<Fact>]
let ``given input AA BB should return 2 matches for regex`` () =
    Assert.Equal(2, getNumberOfMatches "[A-Z]{2,}" "AA BB")
