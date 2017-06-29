﻿module BobTest

open Xunit
open Bob

[<Fact>]
let ``Stating something`` () =
    Assert.True(hey "Tom-ay-to, tom-aaaah-to." = "Whatever.")

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Shouting`` () =
//     Assert.That(hey "WATCH OUT!", Is.EqualTo("Whoa, chill out!"))

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Asking a question`` () =
//     Assert.That(hey "Does this cryogenic chamber make me look fat?", Is.EqualTo("Sure."))

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Asking a numeric question`` () =
//     Assert.That(hey "You are, what, like 15?", Is.EqualTo("Sure."))

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Forceful questions`` () =
//     Assert.That(hey "WHAT THE HELL WERE YOU THINKING?", Is.EqualTo("Whoa, chill out!"))

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Shouting numbers`` () =
//     Assert.That(hey "1, 2, 3 GO!", Is.EqualTo("Whoa, chill out!"))

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Only numbers`` () =
//     Assert.That(hey "1, 2, 3", Is.EqualTo("Whatever."))

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Question only with numbers`` () =
//     Assert.That(hey "4?", Is.EqualTo("Sure."))

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Shouting with special characters`` () =
//     Assert.That(hey "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!", Is.EqualTo("Whoa, chill out!"))

// [<Fact>]
// [<Ignore("Remove to run test")>]
// let ``Shouting with no exlamation mark`` () =
//     Assert.That(hey "I HATE YOU", Is.EqualTo("Whoa, chill out!"))

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