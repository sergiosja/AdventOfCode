open System.IO
open System.Collections.Generic

let input =
    File.ReadAllLines "input.txt"
    |> Array.head

let rec readGarbage (seq : string) =
    match seq[0] with
    | '!' -> readGarbage seq[2..]
    | '>' -> seq[1..]
    | _ -> readGarbage seq[1..]

let rec readGroups seq w sum =
    if seq = "" then sum
    else
        match seq[0] with
        | '!' -> readGroups seq[2..] w sum
        | '{' -> readGroups seq[1..] (w+1) (sum+w)
        | '}' -> readGroups seq[1..] (w-1) sum
        | '<' ->
            let pastGarbage = readGarbage seq[1..]
            readGroups pastGarbage w sum
        | _ -> readGroups seq[1..] w sum

let part1 =
    readGroups input 1 0
    |> printfn "%d"

let rec countGarbage seq sum isCounting =
    if seq = "" then sum
    else
        match seq[0] with
        | '!' -> countGarbage seq[2..] sum isCounting
        | '<' -> countGarbage seq[1..] (if isCounting then sum+1 else sum) true
        | '>' -> countGarbage seq[1..] sum false
        | _ -> countGarbage seq[1..] (if isCounting then sum+1 else sum) isCounting

let part2 =
    countGarbage input 0 false
    |> printfn "%d"