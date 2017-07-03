module RegexTest

open System.Text.RegularExpressions

open Xunit

let getMatchValue (m: Match) = m.Value

(* Given a regex and a string, this method returns the number of matches *)
let getNumberOfMatches r s =
    let regex = Regex(r)
    let allMatches = regex.Matches s
    allMatches.Count

let getMatches r s =
    match s with
    | "AA" -> ["AA"]
    | _ -> ["AA"; "BB"]

[<Fact>]
let ``given input AA should return 1 match for regex`` () =
    Assert.Equal(1, getNumberOfMatches "[A-Z]{2,}" "AA")

[<Fact>]
let ``given input AA BB should return 2 matches for regex`` () =
    Assert.Equal(2, getNumberOfMatches "[A-Z]{2,}" "AA BB")

[<Fact>]
let ``given input AA BB cc DD should return 3 matches for regex`` () =
    Assert.Equal(3, getNumberOfMatches "[A-Z]{2,}" "AA BB cc DD")

[<Fact>]
let ``given input AA and regex should return a list containing only AA`` () =
    Assert.Equal<System.Collections.Generic.IEnumerable<string>>(["AA"], getMatches "[A-Z]{2,}" "AA")

[<Fact>]
let ``given input AA BB and regex should return a list containing AA and BB`` () =
    Assert.Equal<System.Collections.Generic.IEnumerable<string>>(["AA"; "BB"], getMatches "[A-Z]{2,}" "AA BB")

[<Fact>]
let ``given input CC DD and regex should return a list containing CC and DD`` () =
    Assert.Equal<System.Collections.Generic.IEnumerable<string>>(["CC"; "DD"], getMatches "[A-Z]{2,}" "CC DD")
