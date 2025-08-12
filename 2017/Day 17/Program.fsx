open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.head
    |> int

let insert currIdx (xs : int list) =
    let spot = (currIdx + input) % xs.Length
    let xs' = xs[..spot] @ [xs.Length] @ xs[spot+1..]
    (spot+1) % xs'.Length, xs'

let rec insertrec (idx, xs : int list) =
    if xs.Length = 2018 then
        xs[idx+1]
    else
        insertrec (insert idx xs)

let part1 =
    insertrec (1, [0; 1])
    |> printfn "%d"


let rec circ idx size target =
    if size = 50000001 then
        target
    else
        let idx' = (idx+input) % size
        let target' = if idx' = 0 then size else target
        circ ((idx'+1)%(size+1)) (size+1) target'

let part2 =
    circ 1 2 1
    |> printfn "%d"