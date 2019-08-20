module demo1.ResultTestHelpers

open FsUnit.Xunit

let fail = true |> should equal false

let hasCorrectErrorMessage expectedErrorMessage result =
    match result with
    | Error msg -> msg |> should equal expectedErrorMessage
    | _ -> fail

let isOkAndEquals getFn expectedInnerValue result =
    match result with
    | Error _ -> fail
    | Ok content -> getFn content |> should equal expectedInnerValue
