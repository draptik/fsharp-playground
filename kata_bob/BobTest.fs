module BobTest

open Xunit
open Bob

[<Fact>]
let ``Stating something`` () =
    Assert.True(hey "Tom-ay-to, tom-aaaah-to." = "Whatever.")

[<Fact>]
let ``Shouting`` () =
    Assert.True(hey "WATCH OUT!" = "Whoa, chill out!")

[<Fact>]
let ``Asking a question`` () =
    Assert.True(hey "Does this cryogenic chamber make me look fat?" = "Sure.")

[<Fact>]
let ``Asking a numeric question`` () =
    Assert.True(hey "You are, what, like 15?" = "Sure.")

[<Fact>]
let ``Forceful questions`` () =
    Assert.True(hey "WHAT THE HELL WERE YOU THINKING?" = "Whoa, chill out!")

[<Fact>]
let ``Shouting numbers`` () =
    Assert.True(hey "1, 2, 3 GO!" = "Whoa, chill out!")

[<Fact>]
let ``Only numbers`` () =
    Assert.True(hey "1, 2, 3" = "Whatever.")

[<Fact>]
let ``Question only with numbers`` () =
    Assert.True(hey "4?" = "Sure.")

[<Fact>]
let ``Shouting with special characters`` () =
    Assert.True(hey "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!" = "Whoa, chill out!")

[<Fact>]
let ``Shouting with no exlamation mark`` () =
    Assert.True(hey "I HATE YOU" = "Whoa, chill out!")

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Statement containing question mark`` () =
//     Assert.That(hey "Ending with ? means a question.", Is.EqualTo("Whatever."))

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Prattling on`` () =
//     Assert.That(hey "Wait! Hang on. Are you going to be OK?", Is.EqualTo("Sure."))

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Silence`` () =
//     Assert.That(hey "", Is.EqualTo("Fine. Be that way!"))

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Prolonged silence`` () =
//     Assert.That(hey "    ", Is.EqualTo("Fine. Be that way!"))

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Multiple line question`` () =
//     Assert.That(hey "Does this cryogenic chamber make me look fat?\nno", Is.EqualTo("Whatever."))