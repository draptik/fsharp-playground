module Tests

open FsUnit.Xunit
open Xunit

open TicTacToe

[<Fact>]
let ``Cell picked by playerX is not included in valid moves for playerO`` () =
    let initialGameState = { Cells = initialCells }
    let pos = (Left, Top)

    let result = playerXMoves (initialGameState, PlayerXPos pos)

    match result with
    | PlayerOMovesNext (_, moves) ->
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
    | PlayerOMovesNext (gamestate, _) ->
        gamestate.Cells
        |> List.contains { pos = pos; state = OccupiedBy PlayerX }
        |> should equal true
    | _ -> Assert.True(false)

[<Fact>]
let ``PlayerX wins if top row is occupied by playerX`` () =
    let cells = [
        { pos = Left, Top; state = OccupiedBy PlayerX }
        { pos = HCenter, Top; state = OccupiedBy PlayerX }
        { pos = Right, Top; state = Empty }
        { pos = Left, VCenter; state = Empty }
        { pos = HCenter, VCenter; state = Empty }
        { pos = Right, VCenter; state = Empty }
        { pos = Left, Bottom; state = Empty }
        { pos = HCenter, Bottom; state = Empty }
        { pos = Right, Bottom; state = Empty }
    ]

    let gameState = { Cells = cells }

    let result = playerXMoves (gameState, PlayerXPos (Right, Top))

    match result with
    | GameWon (_, player) -> player |> should equal PlayerX
    | _ -> Assert.True(false)

[<Fact>]
let ``PlayerX wins if vertical center row is occupied by playerX`` () =
    let cells = [
        { pos = Left, Top; state = Empty }
        { pos = HCenter, Top; state = OccupiedBy PlayerX }
        { pos = Right, Top; state = Empty }
        { pos = Left, VCenter; state = Empty }
        { pos = HCenter, VCenter; state = OccupiedBy PlayerX }
        { pos = Right, VCenter; state = Empty }
        { pos = Left, Bottom; state = Empty }
        { pos = HCenter, Bottom; state = Empty }
        { pos = Right, Bottom; state = Empty }
    ]

    let gameState = { Cells = cells }

    let result = playerXMoves (gameState, PlayerXPos (HCenter, Bottom))

    match result with
    | GameWon (_, player) -> player |> should equal PlayerX
    | _ -> Assert.True(false)

[<Fact>]
let ``PlayerX wins if diagonal row (top left to bottom right) is occupied by playerX`` () =
    let cells = [
        { pos = Left, Top; state = OccupiedBy PlayerX }
        { pos = HCenter, Top; state = Empty }
        { pos = Right, Top; state = Empty }
        { pos = Left, VCenter; state = Empty }
        { pos = HCenter, VCenter; state = OccupiedBy PlayerX }
        { pos = Right, VCenter; state = Empty }
        { pos = Left, Bottom; state = Empty }
        { pos = HCenter, Bottom; state = Empty }
        { pos = Right, Bottom; state = OccupiedBy PlayerX }
    ]

    let gameState = { Cells = cells }

    let result = playerXMoves (gameState, PlayerXPos (HCenter, Bottom))

    match result with
    | GameWon (_, player) -> player |> should equal PlayerX
    | _ -> Assert.True(false)

[<Fact>]
let ``Tie is recognized`` () =
    let cells = [
        { pos = Left, Top; state = OccupiedBy PlayerO }
        { pos = HCenter, Top; state = OccupiedBy PlayerO }
        { pos = Right, Top; state = OccupiedBy PlayerX }
        { pos = Left, VCenter; state = OccupiedBy PlayerX }
        { pos = HCenter, VCenter; state = OccupiedBy PlayerX }
        { pos = Right, VCenter; state = OccupiedBy PlayerO }
        { pos = Left, Bottom; state = OccupiedBy PlayerO }
        { pos = HCenter, Bottom; state = OccupiedBy PlayerX }
        { pos = Right, Bottom; state = OccupiedBy PlayerX }
    ]

    let gameState = { Cells = cells }

    let result = playerXMoves (gameState, PlayerXPos (HCenter, Bottom))

    match result with
    | GameTied _ -> Assert.True(true)
    | _ -> Assert.True(false)
