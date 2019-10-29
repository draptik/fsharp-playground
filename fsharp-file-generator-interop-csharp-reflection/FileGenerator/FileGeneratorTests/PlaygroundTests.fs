module FileGeneratorTests.PlaygroundTests

open CSharpLib
open FileGeneratorTests.Playground
open FsUnit.Xunit
open Xunit
open Swensen.Unquote

[<Fact>]
let ``Enum values`` () =
    enumToList<Sample>
    |> should equal [Sample.Foo; Sample.Bar; Sample.Baz]

[<Fact>]
let ``Enum values with unquote`` () =
    test <@ enumToList<Sample> = [Sample.Foo; Sample.Bar; Sample.Baz] @>
    
[<Fact>]
let ``Get description for enum value`` () =
    let result = getDescription<Sample> Sample.Bar
    result |> should equal "Bar description"

[<Fact>]
let ``Combining enum functions`` () =
    test <@ enumToList<Sample>
    |> List.map getDescription<Sample>
    = ["Foo description"; "Bar description"; "Baz description"] @>
    
[<Fact>]
let ``Combining functions`` () =
    combinedFcn1<Sample>
    |> should equal ["Foo description"; "Bar description"; "Baz description"]
    
[<Fact>]
let ``enum to int values`` () =
    let foo = enumToIntList<Sample>
    foo
    |> should equal [1; 2; 99]
    
[<Fact>]
let ``enum to tuple`` () =
    test <@ enumToTuple<Sample> = [(Sample.Foo, 1); (Sample.Bar, 2); (Sample.Baz, 99)] @>
    
[<Fact>]
let ``enum to tuple with all props`` () =
    test <@ enumToCompleteTuple<Sample>
                = [
                    (Sample.Foo, 1, "Foo description");
                    (Sample.Bar, 2, "Bar description");
                    (Sample.Baz, 99, "Baz description")
                ] @>
        