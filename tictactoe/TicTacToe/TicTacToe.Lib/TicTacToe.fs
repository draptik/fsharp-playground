module TicTacToe

type HorizPosition = Left | HCenter | Right
type VertPosition = Top | VCenter | Bottom

type CellPosition = HorizPosition * VertPosition

type Line = Line of CellPosition list

type Player = PlayerO | PlayerX

type CellState = Played of Player | Empty

type Cell = { pos: CellPosition; state: CellState }

let initialCells = [
    { pos = Left, Top; state = Empty }
    { pos = HCenter, Top; state = Empty }
    { pos = Right, Top; state = Empty }
    { pos = Left, VCenter; state = Empty }
    { pos = HCenter, VCenter; state = Empty }
    { pos = Right, VCenter; state = Empty }
    { pos = Left, Bottom; state = Empty }
    { pos = HCenter, Bottom; state = Empty }
    { pos = Right, Bottom; state = Empty }
]

type GameState = { Cells: Cell list }

type PlayerXPos = PlayerXPos of CellPosition 
type PlayerOPos = PlayerOPos of CellPosition 

let unwrapPlayerOPos playerOPos =
    let (PlayerOPos pos) = playerOPos
    pos

type ValidMovesForPlayerX = PlayerXPos list
type ValidMovesForPlayerO = PlayerOPos list
    
type MoveResult = 
    | PlayerXToMove of GameState * ValidMovesForPlayerX 
    | PlayerOToMove of GameState * ValidMovesForPlayerO 
    | GameWon of GameState * Player 
    | GameTied of GameState

// private ---------------------------------------
type HasWon = Player * GameState -> bool
let hasWon : HasWon =
    fun (pl, gs) ->
        
        /// the list of all horizontal positions
        let allHorizPositions = [Left; HCenter; Right]
        
        /// the list of all vertical positions
        let allVertPositions = [Top; VCenter; Bottom]

        /// a list of the eight lines to check for 3 in a row : Line list (Line is a list of CellPositions, so linesToCheck is a list of lists)
        let linesToCheck = 
            let mkHLine v = [for h in allHorizPositions do yield (h,v)]
            let hLines= [for v in allVertPositions do yield mkHLine v] 

            let mkVLine h = [for v in allVertPositions do yield (h,v)]
            let vLines = [for h in allHorizPositions do yield mkVLine h] 

            let diagonalLine1 = [Left,Top; HCenter,VCenter; Right,Bottom]
            let diagonalLine2 = [Left,Bottom; HCenter,VCenter; Right,Top]

            // return all the lines to check
            [
            yield! hLines
            yield! vLines
            yield diagonalLine1 
            yield diagonalLine2 
            ]
            
        let cellWasPlayedBy player cell =
            match cell.state with
            | Played played -> played = player
            | Empty -> false
        
        let getCell gs posToFind = 
            gs.Cells 
            |> List.find (fun cell -> cell.pos = posToFind)

        let singleLineCheck player (line: CellPosition list) : bool =
            line |> List.map (getCell gs) |> List.forall (cellWasPlayedBy player)
        
        let multilinecheck player (lines: CellPosition list list) : bool =
            lines |> List.exists (singleLineCheck player) 
        
        linesToCheck |> multilinecheck pl

type AreAllCellsOccupied = GameState -> bool
let areAllCellsOccupied : AreAllCellsOccupied =
    fun gameState ->
        gameState.Cells |> List.forall (fun x -> x.state <> Empty) 

type UpdateCells = Cell list * CellPosition * Player -> Cell list
let updateCells : UpdateCells =
    fun (cells, cellPosition, player) ->
        cells
        |> List.map (fun x ->
            if x.pos = cellPosition then
                { x with state = Played player }
            else
                x)

type NewGameState = GameState * Player * CellPosition -> GameState
let newGameState : NewGameState =
    fun (gameState, player, cellPos) ->
        let newCell = { pos = cellPos; state = Played player }
        let newCells = updateCells (gameState.Cells, newCell.pos, player)
        { Cells = newCells }

// public -----------------------------------------
type PlayerXMoves = GameState * PlayerXPos -> MoveResult
let playerXMoves : PlayerXMoves =
    fun (gameState, playerXPos) ->

        let currentPlayer = PlayerX

        let (PlayerXPos cellPos) = playerXPos

        let newGameState = newGameState (gameState, currentPlayer, cellPos)
        
        if hasWon (currentPlayer, newGameState) then
            GameWon (newGameState, currentPlayer)
        else if areAllCellsOccupied newGameState then
            GameTied newGameState
        else
            let (validMovesForPlayerO: ValidMovesForPlayerO) =
                newGameState.Cells
                |> List.filter (fun x -> x.state = Empty)
                |> List.map (fun x -> PlayerOPos x.pos)
            PlayerOToMove (newGameState, validMovesForPlayerO)

type PlayerOMoves = GameState * PlayerOPos -> MoveResult
let playerOMoves : PlayerOMoves =
    fun (gameState, playerOPos) ->

        let currentPlayer = PlayerO

        let (PlayerOPos cellPos) = playerOPos

        let newGameState = newGameState (gameState, currentPlayer, cellPos)
        
        if hasWon (currentPlayer, newGameState) then
            GameWon (newGameState, currentPlayer)
        else if areAllCellsOccupied newGameState then
            GameTied newGameState
        else
            let (validMovesForPlayerX: ValidMovesForPlayerX) =
                newGameState.Cells
                |> List.filter (fun x -> x.state = Empty)
                |> List.map (fun x -> PlayerXPos x.pos)
            PlayerXToMove (newGameState, validMovesForPlayerX)
