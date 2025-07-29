open System.IO

let input =
    File.ReadAllLines("input.txt")
    |> Array.map (fun line ->
        let parts = line.Split(": ")
        let target = int64 parts.[0]
        let nums = parts.[1].Split(" ") |> Array.map int64 |> Array.toList
        (target, nums)
    )
    |> Array.toList

let rec calibrate target nums acc =
    match nums with
    | [] -> target = acc
    | x :: xs ->
        if acc > target then false
        else
            calibrate target xs (x + acc) ||
            calibrate target xs (x * acc) ||
            calibrate target xs (int64 (string acc + string x))

let part1 =
    input
    |> List.sumBy (fun (target, nums) ->
        if calibrate target nums 0L then target else 0L)
    |> printfn "%d"
