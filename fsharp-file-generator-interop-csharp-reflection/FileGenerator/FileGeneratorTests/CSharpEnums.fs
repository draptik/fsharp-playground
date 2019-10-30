module FileGeneratorTests.CSharpEnums

open System
open System.ComponentModel

type Name = Name of string
type Value = Value of int
type Description = Description of string

type CSharpEnumEntry<'a> = {
    Name: Name
    Value: Value
    Description: Description
}

let getEnumValues<'a> = System.Enum.GetValues(typeof<'a>)

let castToEnumEntry<'a> (array: Array) = array :?> ('a []) |> Array.toList

let castToInts<'a> (array: Array) = array :?> (int []) |> Array.toList

let getDescription<'a> (enumValue: 'a) =
    let t = typeof<'a>
    let memInfo = t.GetMember(enumValue.ToString())
    let attributes = memInfo.[0].GetCustomAttributes(typeof<DescriptionAttribute>, false)
    let attribute = attributes.[0]
    let descriptionAttribute = attribute :?> DescriptionAttribute
    descriptionAttribute.Description


let castToDescription<'a> (array: Array) =
    castToEnumEntry<'a> array |> List.map getDescription<'a>

let enumTupleToCSharpEnumEntry<'a> (tuple: 'a * int * string) =
    let (name, value, description) = tuple
    {
        Name = Name (name.ToString())
        Value = Value value
        Description = Description description
    }
    
let enumToCSharpEnumEntries<'a> =
    let enumValues = getEnumValues<'a>
    let tuples = List.zip3
                     (castToEnumEntry<'a> enumValues)
                     (castToInts<'a> enumValues)
                     (castToDescription<'a> enumValues)

    tuples
    |> List.map enumTupleToCSharpEnumEntry<'a>
