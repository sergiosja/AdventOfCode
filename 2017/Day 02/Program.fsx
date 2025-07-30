open System.IO

let input =
    File.ReadAllLines("input.txt")
    |> Array.map (fun line -> line.Split("\t"))
    |> Array.map (Array.map int)

let last (xs: int array) = xs[xs.Length-1]

let greatestDiff (xs: int array) =
    Array.head xs - last xs

let part1 =
    input
    |> Array.map Array.sortDescending
    |> Array.map greatestDiff
    |> Array.sum
    |> printfn "%d"

let isInt (value: float) =
    value = System.Math.Round value

// bleh
let dividesEvenly xs =
    [|
        for i in 0 .. Array.length xs - 2 do
            for j in i + 1 .. Array.length xs - 1 do
                let value = xs.[i]/xs.[j]
                yield if isInt value then value else 0.0
    |]

let part2 =
    input
    |> Array.map Array.sortDescending
    |> Array.map (fun xs -> xs |> Array.map float)
    |> Array.map dividesEvenly
    |> Array.map (fun xs -> xs |> Array.filter (fun x -> x > 0.0))
    |> Array.sumBy (fun xs -> Array.head xs)
    |> printfn "%O"
