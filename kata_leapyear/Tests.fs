module Tests

open System
open Xunit

open Version1
open Version2
open Version3
open Version4
open Version5


let isLeapYear num =
    // Version1.IsLeapYear num
    // Version2.IsLeapYear num
    // Version3.IsLeapYear num
    // Version4.IsLeapYear num
    Version5.IsLeapYear num

[<Fact>]
let ``Is 1996 a valid leap year`` () = 
    Assert.True(isLeapYear 1996)

[<Fact>]
let ``Is 1997 an invalid leap year`` () = 
    Assert.False(isLeapYear 1997)

[<Fact>]
let ``Is the turn of the 20th century an invalid leap year`` () = 
    Assert.False(isLeapYear 1900)

[<Fact>]
let ``Is the turn of the 25th century a valid leap year`` () = 
    Assert.True(isLeapYear 2400)    