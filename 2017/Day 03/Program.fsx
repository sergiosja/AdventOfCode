open System.IO

type C = (int * int * int)

// I calculated that 526^2 < my puzzle input < 527^2
// That is where I get this number from :')
let BIGGEST_SQRT = 527
let mid = BIGGEST_SQRT / 2

let input =
    File.ReadAllLines "input.txt"
    |> Array.head
    |> int

let findClosestPerfectSquare start target =
    let rec inner x =
        let x' = x * x
        if x' >= target then x', x else inner (x + 2)
    inner start

let flipMinus x y = y - x

let part1 =
    input
    |> findClosestPerfectSquare BIGGEST_SQRT
    |> (fun (x, y) -> flipMinus input x, y)
    |> (fun (x, y) -> flipMinus x y - 1)
    |> printfn "%d"

let initMatrix =
    let m =
        Array2D.init
            (BIGGEST_SQRT + 1)
            (BIGGEST_SQRT + 1)
            (fun row col ->
                col, row, 0
            )
    m.[mid, mid] <- mid, mid, 1
    m

let trd ((_, _, value) : C) =
    value

let isValid (x, y) =
    0 <= x && x <= BIGGEST_SQRT &&
    0 <= y && y <= BIGGEST_SQRT

let getIfValid (m : C array2d) (x, y) =
    if isValid (x, y) then
        trd m.[x, y]
    else 0

let neighbourSum (m : C array2d) (x, y) =
    getIfValid m (x-1, y-1) + getIfValid m (x-1, y) + getIfValid m (x-1, y+1) +
    getIfValid m (x+1, y-1) + getIfValid m (x+1, y) + getIfValid m (x+1, y+1) +
    getIfValid m (x, y-1) + getIfValid m (x, y+1)


type Dir = Right | Up | Left | Down

let changeDir dir =
    match dir with
    | Right -> Up
    | Up -> Left
    | Left -> Down
    | Down -> Right

let move (x, y) dir =
    match dir with
    | Right -> x, y+1
    | Up -> x-1, y
    | Left -> x, y-1
    | Down -> x+1, y

let updateSquare (m : C array2d) (x, y) =
    if isValid (x, y) then
        let _, _, value = m.[x, y]
        if value = 0 then
            m.[x, y] <- y, x, neighbourSum m (x, y)
            m
        else m
    else m

let rec traverseSquares (m : C array2d) (x, y) (dir: Dir) stepsLeft steps =
    let m' = updateSquare m (x, y)
    let _, _, value = m'.[x, y]
    if value > input then
        value
    else
        if stepsLeft = 0 then
            let nextDir = changeDir dir
            let currentGlobalSteps =
                match dir with
                | Up | Down -> steps + 1
                | _ -> steps

            let x', y' = move (x, y) nextDir
            traverseSquares m' (x', y') nextDir (currentGlobalSteps-1) currentGlobalSteps
        else
            let x', y' = move (x, y) dir
            traverseSquares m' (x', y') dir (stepsLeft - 1) steps

let part2 =
    traverseSquares initMatrix (mid, mid) Right 1 1
    |> printfn "%d"
