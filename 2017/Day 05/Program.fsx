open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.map int

let move (nums : int array) =
    let mutable idx = 0
    let mutable counter = 0

    while idx < nums.Length do
        let value = nums[idx]
        nums[idx] <- nums[idx] + 1
        idx <- idx + value
        counter <- counter + 1
    counter

let part1 =
    Array.copy input
    |> move
    |> printfn "%d"

let move2 (nums : int array) =
    let mutable idx = 0
    let mutable counter = 0

    while idx < nums.Length do
        let value = nums[idx]
        nums[idx] <- if value >= 3 then nums[idx]-1 else nums[idx]+1
        idx <- idx + value
        counter <- counter + 1
    counter

let part2 =
    Array.copy input
    |> move2
    |> printfn "%d"
