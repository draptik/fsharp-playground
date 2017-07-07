module GigasecondTest

open Xunit
open Gigasecond
open System

[<Fact>]
let ``First date`` () =
    let input = DateTime(2011, 4, 25)
    Assert.Equal(DateTime(2043, 1, 1), gigasecond input)

[<Fact>]
let ``Another date`` () =
    let input = DateTime(1977, 6, 13)
    Assert.Equal(DateTime(2009, 2, 19), gigasecond input)

[<Fact>]
let ``Yet another date`` () =
    let input = DateTime(1959, 7, 19)
    Assert.Equal(DateTime(1991, 3, 27), gigasecond input)