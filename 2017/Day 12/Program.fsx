open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.map (fun s -> s.Split " <-> ")
    |> Array.map (fun s -> int s[0], s[1].Split ", " |> Array.map int)

let makeGraph (xs : (int * int array) array) =
    let graph = Array.create input.Length Set.empty
    xs
    |> Array.iter (fun (root, nodes) ->
        nodes
        |> Array.iter (fun node ->
            graph[root] <- Set.add node graph[root]
        )
    )
    graph

let rec bfs (graph : int Set array) (queue : int array) (visited : int Set) =
    if Array.isEmpty queue then
        visited
    else
        let node = Array.head queue
        if Set.contains node visited then
            let queue' = queue |> Array.tail
            bfs graph queue' visited
        else
            let visited' = Set.add node visited
            let queue' = Array.append (queue |> Array.tail) (graph[node] |> Set.toArray)
            bfs graph queue' visited'

let part1 =
    bfs (makeGraph input) (Array.create 1 0) Set.empty
    |> Set.count
    |> printfn "%d"

let part2 =
    let graph = makeGraph input

    input
    |> Array.map fst
    |> Array.map (fun x ->
        bfs graph (Array.create 1 x) Set.empty
    )
    |> Array.distinct
    |> Array.length
    |> printfn "%d"
