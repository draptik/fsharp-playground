module Tests

open System
open FsUnit.Xunit
open Xunit

open TicTacToe
open TicTacToe
open TicTacToe
open TicTacToe

[<Fact>]
let ``Player X starts game`` () =
    let initialGameState = { Cells = initialCells }
    let pos = (Left, Top)
    let xPos = PlayerXPos pos
    let result = playerXMoves (initialGameState, xPos)
    match result with
    | PlayerOToMove (gs, moves) -> Assert.True(true)
    | _ -> Assert.True(false)
    
[<Fact>]
let ``Cell picked by playerX is not included in valid moves for playerO`` () =
    let initialGameState = { Cells = initialCells }
    let pos = (Left, Top)

    let result = playerXMoves (initialGameState, PlayerXPos pos)
    
    match result with
    | PlayerOToMove (_, moves) ->
        moves
        |> List.map (fun x -> unwrapPlayerOPos x)
        |> List.exists (fun x -> x = pos)
        |> should equal false
    | _ -> Assert.True(false)
    
[<Fact>]
let ``Cell picked by playerX is occupied by playerX in new game state`` () =
    let initialGameState = { Cells = initialCells }
    let pos = (Left, Top)

    let result = playerXMoves (initialGameState, PlayerXPos pos)
    
    match result with
    | PlayerOToMove (gamestate, _) ->
        gamestate.Cells
        |> List.contains { pos = pos; state = Played PlayerX }
        |> should equal true
    | _ -> Assert.True(false)
    
