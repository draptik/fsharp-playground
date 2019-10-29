module FileGeneratorTests.Domain

//open System.ComponentModel;
//open CSharpLib

//type EntryName = EntryName of string
//type EntryType = EntryType of string
//type Value = Value of string
//type DefaultValue = DefaultValue of Value
//
//type ConfigEntry = {
//    Name: EntryName
//    Type: EntryType
//    DefaultValue: DefaultValue
//}
//
//type ConfigForEnumEntry = {
//    EnumName: string
//    Type: EntryType
//    Value: Value
//}
//
//type EnumName = EnumName of string
//
//type ConfigForEnum = {
//    EnumName: EnumName
//    ConfigEntries: ConfigEntry list
//    ConfigsForEnumEntries: ConfigForEnumEntry list
//}
//

//type IsPositive = int -> bool
//let isPositive: IsPositive = fun x -> x > 0 

//type EnumEntry = {
//    Type: string
//    Name: string
//}
//
//let destructureEnumValue x =
//    (x.ToString(), (int) x)



//let getDescriptionSimple =
//    let t = Sample.Bar.GetType()
//    let memInfo = t.GetMember(Sample.Bar.ToString())
//    let attributes = memInfo.[0].GetCustomAttributes(typeof<DescriptionAttribute>, false)
//    let attribute = attributes.[0]
//    let descriptionAttribute = attribute :?> DescriptionAttribute
//    descriptionAttribute.Description


    
//type EnumData = {
//    Name: string
//    Entries: EnumEntry list
//}
//
//
//type CreateEnumData = System.Type -> EnumData

//let createEnumData : CreateEnumData = fun x -> {Name = x.Name; Entries = System.Enum. }