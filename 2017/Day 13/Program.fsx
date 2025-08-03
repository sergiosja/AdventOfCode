open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.map (fun s -> s.Split ": ")
    |> Array.map (fun s -> int s[0], int s[1])

let scannerTopIdx x = (x-1) * 2

let packetIsCaught (idx, range) =
    if idx % (scannerTopIdx range) = 0 then
        idx * range
    else 0

let part1 =
    input
    |> Array.sumBy packetIsCaught
    |> printfn "%d"

let getScannerIdx firewall delay =
    let idx, range = firewall
    let cycle = scannerTopIdx range
    let pos = (idx+delay) % cycle
    if pos < range then
        pos
    else cycle - pos

let rec movePacket packetIdx delay (firewall : (int * int) array) =
    if packetIdx > firewall.Length - 1 then
        delay
    elif getScannerIdx firewall[packetIdx] delay = 0 then
        movePacket 0 (delay+1) firewall
    else
        movePacket (packetIdx+1) delay firewall

let part2 =
    input
    |> movePacket 0 0
    |> printfn "%d"

