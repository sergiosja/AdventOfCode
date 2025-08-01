open System.IO

let input : (string * string Set) array  =
    File.ReadAllLines "input.txt"
    |> Array.map (fun s -> s.Split " ")
    |> Array.filter (fun o -> o.Length > 2)
    |> Array.map (fun o -> o[0], o[3..] |> Array.map (fun p -> p.Replace(",", "")))
    |> Array.map (fun (x, y) -> x, Set.ofArray y)

let findRepeat (xs : (string * string Set) array) =
    xs
    |> Array.map fst
    |> Array.find (fun target ->
        xs
        |> Array.map snd
        |> Array.forall (fun set -> not (Set.contains target set))
    )

let part1 =
    input
    |> findRepeat
    |> printfn "%A"