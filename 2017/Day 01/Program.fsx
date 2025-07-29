open System.IO

let input =
    File.ReadAllLines("input.txt")
    |> Seq.head

let shiftSeq (s: string) =
    s[1..s.Length-1] + $"{s[0]}"

let zipSeq s = s |> Seq.zip (shiftSeq s)

let sumDuplicates z (nums : seq<(char * char)>) =
    nums
    |> Seq.map (fun (x, y) -> if x = y then x else '0')
    |> Seq.map (fun x -> (int x - int '0') * z)
    |> Seq.sum

let part1 =
    input
    |> zipSeq
    |> sumDuplicates 1
    |> printfn "%d"

let zipHalves (s: string) =
    s[..s.Length/2]
    |> Seq.zip s[s.Length/2..]

let part2 =
    input
    |> zipHalves
    |> sumDuplicates 2
    |> printfn "%d"