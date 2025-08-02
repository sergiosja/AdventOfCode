open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.head
    |> fun s -> s.Split ","

let move (x, y, z) dir =
    match dir with
    | "nw" -> x-1,y+1,z
    | "n" -> x,y+1,z-1
    | "ne" -> x+1,y,z-1
    | "sw" -> x-1,y,z+1
    | "s" -> x,y-1,z+1
    | _ (* "se" *) -> x+1,y-1,z

let part1 = 
    input
    |> Array.fold move (0,0,0)
    |> fun (x,y,z) -> (abs x + abs y + abs z) / 2
    |> printfn "%d"

let part2 =
    input
    |> Array.scan move (0,0,0)
    |> Array.map (fun (x,y,z) -> (abs x + abs y + abs z) / 2)
    |> Array.max
    |> printfn "%d"
