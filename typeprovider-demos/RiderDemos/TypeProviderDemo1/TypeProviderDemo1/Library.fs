module Library

open FSharp.Data.Sql

let [<Literal>] dbVendor = Common.DatabaseProviderTypes.POSTGRESQL
let [<Literal>] connectionString = "" 
let [<Literal>] resolutionPath = "" 


type sql = SqlDataProvider<Common.DatabaseProviderTypes.POSTGRESQL, connectionString>
