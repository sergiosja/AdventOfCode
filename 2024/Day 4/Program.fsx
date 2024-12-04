open System.IO

let input =
    File.ReadAllLines("input.txt")
    |> Array.map (fun s -> s.ToCharArray() |> Array.toList)
    |> Array.toList

let withinBounds puzzle x y =
    puzzle
    |> List.tryItem x
    |> Option.bind (fun row -> List.tryItem y row)

let directions =
    [ (-1, -1); (-1, 0); (-1, 1)
    ; (0, -1); (0, 1)
    ; (1, -1); (1, 0); (1, 1)
    ]

let rec checkDirection puzzle (row, col) (dx, dy) (word: char list) =
    match word with
    | [] -> 1
    | head :: tail ->
        match withinBounds puzzle row col with
        | Some x when x = head ->
            checkDirection puzzle (row+dx, col+dy) (dx, dy) tail
        | _ -> 0

let findXmas puzzle (row, col) (word: char list) =
    directions
    |> List.map (fun (dx, dy) ->
        checkDirection puzzle (row+dx, col+dy) (dx, dy) word)
    |> List.sum

let part1 =
    input
    |> List.mapi (fun i row ->
        row
        |> List.mapi (fun y _ ->
            match input.[i].[y] with
                | 'X' -> findXmas input (i, y) ['M';'A';'S']
                | _ -> 0
        )
    )
    |> List.sumBy List.sum
    |> printfn "%d"

let neighboursWithinBounds puzzle x y =
    [ withinBounds puzzle (x-1) (y-1)
    ; withinBounds puzzle (x+1) (y+1)
    ; withinBounds puzzle (x+1) (y-1)
    ; withinBounds puzzle (x-1) (y+1)
    ]
    |> List.choose id

let findX'Mas puzzle x y =
    match neighboursWithinBounds puzzle x y with
    | [a; b; c; d] when
        ((a = 'M' && b = 'S') || (a = 'S' && b = 'M')) &&
        ((c = 'M' && d = 'S') || (c = 'S' && d = 'M'))
        -> 1
    | _ -> 0

let part2 =
    input
    |> List.mapi (fun i row ->
        row
        |> List.mapi (fun y _ ->
            match input.[i].[y] with
            | 'A' -> findX'Mas input i y
            | _ -> 0
        )
    )
    |> List.sumBy List.sum
    |> printfn "%d"