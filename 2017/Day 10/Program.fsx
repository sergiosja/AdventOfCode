open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.head
    |> fun s -> s.Split ","
    |> Array.map int

let swap (xs : int array) x y =
    let tmp = xs[x]
    xs[x] <- xs[y]
    xs[y] <- tmp
    xs

let rec swapIdxs (xs : int array) (idxs : int array) =
    if idxs.Length > 1 then
        let xs' = swap xs (Array.head idxs) (Array.last idxs)
        swapIdxs xs' (idxs[1..idxs.Length-2])
    else xs

let rec getSublistIdxs idx len count sublistIdxs =
    if count = -1 then
        sublistIdxs |> List.toArray
    else
        let sublistIdxs' = (idx+count) % len :: sublistIdxs
        getSublistIdxs idx len (count-1) sublistIdxs'

let rec tieKnots arr start len countArr skipCount =
    match countArr with
    | [] -> arr, start, skipCount
    | 0 :: rest ->
        tieKnots arr (start+skipCount) len rest (skipCount+1)
    | currCount :: rest ->
        let sublistIdxs = getSublistIdxs start len (currCount-1) []
        let swappedArr = swapIdxs arr sublistIdxs
        tieKnots swappedArr (start+currCount+skipCount) len rest (skipCount+1)

let part1 =
    let arr = [0..255] |> List.toArray

    tieKnots arr 0 arr.Length (input |> Array.toList) 0
    |> fun (x, _, _) -> x
    |> Array.take 2
    |> fun x -> x[0] * x[1]
    |> printfn "%d"

let input2 =
    (File.ReadAllLines "input.txt"
    |> Seq.head
    |> Seq.toList
    |> List.map int
    ) @
    [17;31;73;47;23]

let rec generateHash (arr, idx, skipCount) countArr counter =
    if counter = 0 then
        arr
    else
        let arr', idx', skipCount' = tieKnots arr idx arr.Length countArr skipCount
        generateHash (arr', idx', skipCount') countArr (counter-1)

let rec divideBlocks counter (tbr : int array array) (arr : int array) =
    if counter = 0 then
        tbr |> Array.rev
    else
        divideBlocks (counter-1) (Array.append [|arr[0..15]|] tbr) arr[16..]

let part2 =
    let arr = [0..255] |> List.toArray

    generateHash (arr, 0, 0) input2 64
    |> divideBlocks 16 Array.empty
    |> Array.map (Array.reduce (fun x y -> x ^^^ y ))
    |> Array.map (fun x -> x.ToString "x2")
    |> String.concat ""
    |> printfn "%s"