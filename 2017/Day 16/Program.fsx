open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.head
    |> fun s -> s.Split ","

let LINE = "abcdefghijklmnop"

let mkLine =
    LINE
    |> Seq.fold (fun line x -> Map.add x line.Count line) Map.empty

let shift w (line : Map<char, int>) =
    line
    |> Map.map (fun _ value -> (value + w) % line.Count)

let swapP x y (line : Map<char, int>) =
    line
    |> Map.add x line[y]
    |> Map.add y line[x]

let swapX x y (line : Map<char, int>) =
    let x', y' =
        line
        |> Map.filter (fun _ v -> v = x || v = y)
        |> Map.toArray
        |> Array.map (fun (k, _) -> k)
        |> fun x -> x[0], x[1]
    swapP x' y' line

let restoreLine (line : Map<char, int>) =
    line
    |> Map.toArray
    |> Array.sortBy (fun (_, v) -> v)
    |> Array.map (fun (k, _) -> k)
    |> System.String

let rec dance
    (line : Map<char, int>)
    (times : int)
    (moves : string array)
    =
    if times = 0 then
        line
    elif Array.isEmpty moves then
        input |> dance line (times-1)
    else
        let move = Array.head moves
        match move[0] with
        | 's' ->
            dance (line |> shift (int move[1..])) times (Array.tail moves)
        | 'x' ->
            let x, y = move[1..].Split "/" |> fun arr -> int arr[0], int arr[1]
            dance (line |> swapX x y) times (Array.tail moves)
        | _ (* p *) ->
            let x, y = move[1..].Split "/" |> fun arr -> char arr[0], char arr[1]
            dance (line |> swapP x y) times (Array.tail moves)

let part1 =
    input
    |> dance mkLine 1
    |> restoreLine
    |> printfn "%s"


let rec detectCycle
    (line : Map<char, int>)
    (times : int)
    (moves : string array)
    =
    if restoreLine line = LINE && times > 0 then
        times
    elif Array.isEmpty moves then
        input |> detectCycle line (times+1)
    else
        let move = Array.head moves
        match move[0] with
        | 's' ->
            detectCycle (line |> shift (int move[1..])) times (Array.tail moves)
        | 'x' ->
            let x, y = move[1..].Split "/" |> fun arr -> int arr[0], int arr[1]
            detectCycle (line |> swapX x y) times (Array.tail moves)
        | _ (* p *) ->
            let x, y = move[1..].Split "/" |> fun arr -> char arr[0], char arr[1]
            detectCycle (line |> swapP x y) times (Array.tail moves)

let part2 =
    let cycleRound =
        input
        |> detectCycle mkLine 0
        |> fun x -> 1000000000 % (x+1)

    input
    |> dance mkLine cycleRound
    |> restoreLine
    |> printfn "%s"
