open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.map (fun s -> s.Split())

let part1 =
    input
    |> Array.filter (fun xs -> xs.Length = (Set.ofArray xs).Count)
    |> Array.length
    |> printfn "%d"

let part2 =
    input
    |> Array.map (Array.map (Seq.sort >> Seq.toArray >> System.String))
    |> Array.filter (fun xs -> xs.Length = (Set.ofSeq xs).Count)
    |> Array.length
    |> printfn "%A"
