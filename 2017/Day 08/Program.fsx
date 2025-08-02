open System.IO
open System.Collections.Generic

let input =
    File.ReadAllLines "input.txt"
    |> Array.map (fun s -> s.Split " ")

let populateDict (dict : Dictionary<string, int>) (xs : string array array) =
    for x in xs |> Array.map Array.head do
        if not (dict.ContainsKey x) then
            dict.Add(x, 0)
    dict

let updateDict (dict : Dictionary<string, int>) key newVal =
    dict.Remove key |> ignore
    dict.Add(key, newVal)

let isValid (dict : Dictionary<string, int>) x op n =
    let x' = dict.[x]
    let n' = int n
    match op with
    | ">" -> x' > n'
    | ">=" -> x' >= n'
    | "<" -> x' < n'
    | "<=" -> x' <= n'
    | "==" -> x' = n'
    | _ (* "!=" *) -> x' <> n'

let apply (dict : Dictionary<string, int>) x op n =
    let x' = dict.[x]
    let n' = int n
    match op with
    | "inc" ->
        updateDict dict x (x' + n') ; x' + n'
    | _ (* dec *) ->
        updateDict dict x (x' - n') ; x' - n'

let part1 =
    let mutable dict =
        populateDict (new Dictionary<string, int>()) input

    Array.copy input
    |> Array.iter (fun arr ->
        if isValid dict arr[4] arr[5] arr[6] then
            apply dict arr[0] arr[1] arr[2] |> ignore
        else ()
    )

    dict
    |> Seq.map (fun kvp -> kvp.Value)
    |> Seq.max
    |> printfn "%d"

let part2 =
    let mutable dict =
        populateDict (new Dictionary<string, int>()) input

    Array.copy input
    |> Array.fold (fun currMax arr ->
        if isValid dict arr[4] arr[5] arr[6] then
            let value = apply dict arr[0] arr[1] arr[2]
            max currMax value
        else
            currMax
    ) -1
    |> printfn "%d"
