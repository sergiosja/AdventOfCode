open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.head
    |> fun s -> s.Split "\t"
    |> Array.map int

let getStartSquare xs =
    xs
    |> Array.mapi (fun i v -> i, v)
    |> Array.maxBy snd

let initRedistribution (xs : int array) =
    let idx, value = getStartSquare xs
    xs[idx] <- 0
    xs, idx+1, value

let arrayToString (xs : int array ) =
    xs
    |> Array.map string
    |> String.concat " "

let rec redistribute (xs : int array, idx, value) =
    if value = 0 then
        xs
    else
        let idxMod = idx % xs.Length
        xs[idxMod] <- xs[idxMod]+1
        redistribute (xs, idx+1, value-1)

let rec findRepeat visited (xs : int array) =
    let xsString = arrayToString xs
    if Set.contains xsString visited then
        xs, visited.Count
    else
        xs
        |> initRedistribution
        |> redistribute
        |> findRepeat (Set.add xsString visited)

let findCycle = input |> findRepeat Set.empty

let part1 =
    findCycle
    |> snd
    |> printfn "%d"

let part2 =
    findCycle |> fst
    |> findRepeat Set.empty
    |> snd
    |> printfn "%d"
