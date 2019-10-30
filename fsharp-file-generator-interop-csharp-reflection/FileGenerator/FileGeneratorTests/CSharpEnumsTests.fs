module FileGeneratorTests.CSharpEnumsTests

open CSharpLib
open FileGeneratorTests.CSharpEnums

open CSharpLib
open FsUnit.Xunit
open Xunit
open Swensen.Unquote

[<Fact>]
let ``enum is converted to record type list`` () =
    test <@ enumToCSharpEnumEntries<Sample>
                = [
                     {
                         Name = Name (Sample.Foo.ToString());
                         Value = Value 1;
                         Description = Description "Foo description"
                     };
                     {
                         Name = Name (Sample.Bar.ToString());
                         Value = Value 2;
                         Description = Description "Bar description"
                     };
                     {
                         Name = Name (Sample.Baz.ToString());
                         Value = Value 99;
                         Description = Description "Baz description"
                     };
                ] @>
