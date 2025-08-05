open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.map (fun s -> s.Split " ")
    |> Array.map (fun x -> x |> Array.last |> int64)
    |> fun x -> x[0], x[1]

let nextA a = a * 16807L % 2147483647L
let nextB b = b * 48271L % 2147483647L

let rec generate counter pairs (a,b) =
    if counter = 0 then
        pairs
    else
        generate (counter-1) ((a,b) :: pairs) (nextA a, nextB b)

let judge (a : int64, b : int64) =
    let a' = a &&& 0x0000FFFF
    let b' = b &&& 0x0000FFFF
    if a' = b' then 1 else 0

let part1 =
    input
    |> generate 40000000 []
    |> List.map judge
    |> List.sum
    |> printfn "%d"

let isValid (n : int64) a = a % n = 0L

let rec generateSingle counter values value next isValid =
    if counter = 0 then
        values |> List.rev
    else if isValid value then
        generateSingle (counter-1) (value :: values) (next value) next isValid
    else
        generateSingle counter values (next value) next isValid

let part2 =
    input
    |> fun (a, b) ->
        let a' = generateSingle 5000000 [] a nextA (isValid 4)
        let b' = generateSingle 5000000 [] b nextB (isValid 8)
        List.zip a' b'
    |> List.map judge
    |> List.sum
    |> printfn "%d"