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

let part1 =
    input
    |> List.map List.pairwise
    |> List.map (fun pairs ->
        match pairs.[0] with
        | x, y when x < y -> asc pairs
        | x, y when x > y -> desc pairs
        | _ -> 0)
    |> List.sum
    |> printfn "%d"