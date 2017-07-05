module BobTest

open Xunit
open Bob

[<Fact>]
let ``Stating something`` () =
    Assert.Equal("Whatever.", hey "Tom-ay-to, tom-aaaah-to.")

[<Fact>]
let ``Shouting`` () =
    Assert.Equal("Whoa, chill out!", hey "WATCH OUT!")

[<Fact>]
let ``Asking a question`` () =
    Assert.Equal("Sure.", hey "Does this cryogenic chamber make me look fat?")

[<Fact>]
let ``Asking a numeric question`` () =
    Assert.Equal("Sure.", hey "You are, what, like 15?")

[<Fact>]
let ``Forceful questions`` () =
    Assert.Equal("Whoa, chill out!", hey "WHAT THE HELL WERE YOU THINKING?")

[<Fact>]
let ``Shouting numbers`` () =
    Assert.Equal("Whoa, chill out!", hey "1, 2, 3 GO!")

[<Fact>]
let ``Only numbers`` () =
    Assert.Equal("Whatever.", hey "1, 2, 3")

[<Fact>]
let ``Question only with numbers`` () =
    Assert.Equal("Sure.", hey "4?")

[<Fact>]
let ``Shouting with special characters`` () =
    Assert.Equal("Whoa, chill out!", hey "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!")

[<Fact>]
let ``Shouting with no exlamation mark`` () =
    Assert.Equal("Whoa, chill out!", hey "I HATE YOU")

[<Fact>]
let ``Statement containing question mark`` () =
    Assert.Equal("Whatever.", hey "Ending with ? means a question.")

[<Fact>]
let ``Prattling on`` () =
    Assert.Equal("Sure.", hey "Wait! Hang on. Are you going to be OK?")

[<Fact>]
let ``Silence`` () =
    Assert.Equal("Fine. Be that way!", hey "")

[<Fact>]
let ``Prolonged silence`` () =
    Assert.Equal("Fine. Be that way!", hey "    ")

[<Fact>]
let ``Multiple line question`` () =
    Assert.Equal("Whatever.", hey "Does this cryogenic chamber make me look fat?\nno")