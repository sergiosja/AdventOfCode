open System.IO

let input =
    File.ReadAllLines("input.txt")
    |> Array.map (fun line -> line.Split "   ")
    |> Array.map (fun parts -> int parts.[0], int parts.[1])
    |> Array.toList
    |> List.unzip

let part1 =
    input
    |> fun (x, y) -> List.zip (List.sort x) (List.sort y)
    |> List.sumBy (fun (a, b) -> abs(a - b))

let part2 =
    input
    |> fun (list1, list2) ->
        list1
        |> List.map (fun x -> x * (list2 |> List.filter ((=) x) |> List.length))
        |> List.sum

printfn "%A" part1
printfn "%A" part2