open System.IO

let input =
    File.ReadAllLines "input.txt"
    |> Array.map (fun s -> s.Split " ")

let registers = input

let set k v (table : Map<string, int64>) =
    match Map.tryFind v table with
    | Some v' -> Map.add k v' table
    | None -> Map.add k (int64 v) table

let add k v (table : Map<string, int64>) =
    match Map.tryFind k table with
    | Some kv ->
        match Map.tryFind v table with
        | Some v' -> Map.add k (kv + v') table
        | None -> Map.add k (kv + int64 v) table
    | None -> table

let mul k v (table : Map<string, int64>) =
    match Map.tryFind k table with
    | Some kv ->
        match Map.tryFind v table with
        | Some v' -> Map.add k (kv * v') table
        | None -> Map.add k (kv * int64 v) table
    | None -> table

let mod' k v (table : Map<string, int64>) =
    match Map.tryFind k table with
    | Some kv ->
        match Map.tryFind v table with
        | Some v' -> Map.add k (kv % v') table
        | None -> Map.add k (kv % int64 v) table
    | None -> table


let rec iterateRegisters table pos sound =
    if pos < 0 || pos >= registers.Length then
        sound
    else
        match registers[pos] with
        | [|"set";k;v|] ->
            let table' = set k v table
            iterateRegisters table' (pos+1) sound
        | [|"add";k;v|] ->
            let table' = add k v table
            iterateRegisters table' (pos+1) sound
        | [|"mul";k;v|] ->
            let table' = mul k v table
            iterateRegisters table' (pos+1) sound
        | [|"mod";k;v|] ->
            let table' = mod' k v table
            iterateRegisters table' (pos+1) sound
        | [|"snd";k|] ->
            iterateRegisters table (pos+1) table[k]
        | [|"rcv";k|] ->
            if table[k] = 0 then
                iterateRegisters table (pos+1) sound
            else
                sound
        | [|"jgz";k;v|] ->
            match Map.tryFind k table with
            | Some x ->
                if x = 0 then
                    iterateRegisters table (pos+1) sound
                else
                    iterateRegisters table (pos + int v) sound
            | None ->
                iterateRegisters table (pos+1) sound
        | _ -> sound


let part1 =
    iterateRegisters Map.empty 0 0
    |> printfn "%d"