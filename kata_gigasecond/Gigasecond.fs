module Gigasecond
open System
    
let gigasecond (d:DateTime) =
    d.AddSeconds(1e9).Date