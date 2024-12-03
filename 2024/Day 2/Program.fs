open System.IO

let asc pairs =
    if List.forall (fun (x, y) ->
        List.contains (x - y) [-1; -2; -3]) pairs then 1 else 0

let desc pairs =
    if List.forall (fun (x, y) ->
        List.contains (x - y) [1; 2; 3]) pairs then 1 else 0

let input =
    File.ReadAllLines("input.txt")
    |> Array.map (fun line -> line.Split ' ' |> Array.map int |> Array.toList)
    |> Array.toList

let isSafe lst =
    lst
    |> List.map List.pairwise
    |> List.map (fun pairs ->
        match pairs.[0] with
        | x, y when x < y -> asc pairs
        | x, y when x > y -> desc pairs
        | _ -> 0
    )

let part1 =
    input
    |> isSafe
    |> List.sum
    |> printfn "%d"

let part2 =
    input
    |> List.map (fun lst ->
        lst
        |> List.mapi (fun i _ -> List.take i lst @ List.skip (i+1) lst)
        |> isSafe
        |> List.max
    )
    |> List.sum
    |> printfn "%d"