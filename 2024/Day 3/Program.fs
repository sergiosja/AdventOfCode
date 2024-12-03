open System.IO
open System.Text.RegularExpressions

let pattern = @"mul\(\s*\d{1,3}\s*,\s*\d{1,3}\s*\)"

let input =
    File.ReadAllLines("input.txt")
    |> String.concat "\n"

let matches (needle, haystack) =
    Regex.Matches (needle, haystack)
    |> Seq.toList

let ints (m: Match) =
    Regex.Matches (m.Value, @"\d+")
    |> Seq.map (fun m -> int m.Value)
    |> Seq.toList
    |> function
        | [x; y] -> Some (x, y)
        | _ -> None

let sumInstr lst =
    lst
    |> List.choose ints
    |> List.map (fun (x, y) -> x * y)
    |> List.sum

let matchInstr (sum, active) instr =
    match instr with
    | "do()" -> (sum, true)
    | "don't()" -> (sum, false)
    | _ when active -> (sum + sumInstr (matches (instr, pattern)), active)
    | _ -> (sum, active)

let part1 =
    input
    |> fun x -> matches (x, pattern)
    |> sumInstr
    |> printfn "%d"

let part2 =
    Regex.Split (input, @"(don't\(\)|do\(\))")
    |> Array.toList
    |> List.fold matchInstr (0, true)
    |> fst
    |> printfn "%d"