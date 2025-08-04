open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.head

let generateKeys hash n =
    [0..n]
    |> List.map (fun n' -> $"{hash}-{n'}")
    |> List.toArray

let appendSuffix arr = Array.append arr [|17; 31; 73; 47; 23|]

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

let rec generateHash (arr, idx, skipCount) countArr counter =
    if counter = 0 then
        arr
    else
        let arr', idx', skipCount' = tieKnots arr idx arr.Length countArr skipCount
        generateHash (arr', idx', skipCount') countArr (counter-1)

let generateMap =
    let arr = [|0..255|]

    generateKeys input 127
    |> Array.map (fun s -> s |> Seq.map (fun c -> int c) |> Seq.toArray)
    |> Array.map appendSuffix
    |> Array.map (fun x -> generateHash (arr |> Array.copy, 0, 0) (x |> Array.toList) 64)
    |> Array.map (Array.chunkBySize 16)
    |> Array.map (Array.map (Array.reduce (^^^)))
    |> Array.map (Array.map (fun x -> x.ToString "x2"))
    |> Array.map (Array.map (fun c ->
        let i = System.Convert.ToInt32(c, 16)
        System.Convert.ToString(i, 2).PadLeft(8, '0') 
    ))
    |> Array.map (String.concat "")
    |> Array.map (String.map (fun c -> if c = '1' then '#' else '.'))

let part1 =
    generateMap
    |> Array.map (String.filter (fun c -> c = '#'))
    |> Array.map String.length
    |> Array.sum
    |> printfn "%A"

let MAX = 127

let isValid (x, y) =
    0 <= x && x <= MAX &&
    0 <= y && y <= MAX

let addNeighbour (x, y) (map : string array) visited stack =
    if
        not (Set.contains (x,y) visited) &&
        isValid(x,y) &&
        map[x][y] = '#'
    then
        (x,y) :: stack
    else stack

let addNeighbours (x,y) map visited stack =
    stack
    |> addNeighbour (x-1,y) map visited
    |> addNeighbour (x+1,y) map visited
    |> addNeighbour (x,y-1) map visited
    |> addNeighbour (x,y+1) map visited

let makeNewMap visited map =
    map
    |> Array.mapi (fun x line ->
        line
        |> String.mapi (fun y symbol ->
            if Set.contains (x, y) visited
            then '.' else symbol
        )
    )

let rec dfs
    (visited : (int * int) Set)
    (map : string array)
    (stack : (int * int) list)
    =
    match stack with
    | [] ->
        if visited.Count = 0 then
            0, map
        else
            1, map |> makeNewMap visited
    | s :: tail ->
        if Set.contains s visited || map[fst s][snd s] = '.' then
            dfs visited map tail
        else
            let visited' = Set.add s visited
            addNeighbours s map visited' stack
            |> dfs visited' map

let part2 =
    let mutable map = generateMap
    let mutable sum = 0

    [0..MAX-1]
    |> List.iteri (fun i _ ->
        [0..MAX-1]
        |> List.iteri (fun i' _ ->
            let value, map' = dfs Set.empty map [(i, i')]
            map <- map'
            sum <- sum + value
        )
    )
    |> ignore

    printfn "%d" sum