open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.map (fun s -> s.Split " <-> ")
    |> Array.map (fun s -> int s[0], s[1].Split ", " |> Array.map int |> Set.ofArray)


let rec findPrograms (arr : bool array) connections =
    input
    |> Array.iter (fun (x, set) ->
        if arr[x] = true then
            set |> Set.iter (fun v -> arr[v] <- true)
        elif Set.exists (fun x -> arr[x] = true) set then
            arr[x] <- true
            set |> Set.iter (fun v -> arr[v] <- true)
        else ()
    )

    let connections' =
        arr
        |> Array.filter (fun x -> x = true)
        |> Array.length

    if connections = connections' then
        connections'
    else
        findPrograms arr connections'

let part1 = 
    let arr = Array.create input.Length false
    arr[0] <- true

    findPrograms arr 1
    |> printfn "%d"

let part2 = 1
    // find scc
    // if i have to make a graph anyway I might as well solve the first problem "properly" with bfs too