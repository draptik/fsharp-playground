module FileGeneratorTests.Playground

open System
open System.ComponentModel

let getEnumValues<'a> = System.Enum.GetValues(typeof<'a>)
     
let enumToArray<'a> = getEnumValues<'a> :?> ('a [])
    
let enumToList<'a> = enumToArray<'a> |> Array.toList

let enumToIntArray<'a> = getEnumValues<'a> :?> (int [])
    
let enumToIntList<'a> = enumToIntArray<'a> |> Array.toList
    
let getDescription<'a> (enumValue: 'a) =
    let t = typeof<'a>
    let memInfo = t.GetMember(enumValue.ToString())
    let attributes = memInfo.[0].GetCustomAttributes(typeof<DescriptionAttribute>, false)
    let attribute = attributes.[0]
    let descriptionAttribute = attribute :?> DescriptionAttribute
    descriptionAttribute.Description

    
let combinedFcn1<'a> =
    enumToList<'a>
    |> List.map getDescription<'a>


let enumToTuple<'a> =
    let enumValues = getEnumValues<'a>
    Array.zip (enumValues :?> 'a []) (enumValues :?> int [])
    |> Array.toList

let getDescriptionByTuple<'a> (tuple: 'a * int) =
    let (enumValue, _) = tuple
    getDescription<'a> enumValue

let combinedFcn2<'a> =
    enumToTuple<'a>
    |> List.map getDescriptionByTuple<'a>


let castToEnumEntry<'a> (array: Array) = array :?> ('a []) |> Array.toList

let castToInts<'a> (array: Array) = array :?> (int []) |> Array.toList

let castToDescription<'a> (array: Array) = castToEnumEntry<'a> array |> List.map getDescription<'a>

let enumToCompleteTuple<'a> =
    let enumValues = getEnumValues<'a>
    List.zip3 (castToEnumEntry<'a> enumValues) (castToInts<'a> enumValues) (castToDescription<'a> enumValues) 
