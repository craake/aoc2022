type sign = Rock | Paper | Scissors
type outcome = Win | Lose | Draw

let string_of_sign = function
  | "A" | "X" -> Rock
  | "B" | "Y" -> Paper
  | "C" | "Z" -> Scissors
  | _ -> failwith "Invalid sign"

let string_of_outcome = function
  | "X" -> Lose
  | "Y" -> Draw
  | "Z" -> Win
  | _ -> failwith "Invalid outcome"

let value_of_outcome = function Win -> 6 | Draw -> 3 | Lose -> 0
let value_of_sign = function Rock -> 1 | Paper -> 2 | Scissors -> 3

let game_pt1 s1 s2 =
  let p1 = string_of_sign s1 in
  let p2 = string_of_sign s2 in
  let o =
    match (p2, p1) with
    | Rock, Paper | Paper, Scissors | Scissors, Rock -> Lose
    | Rock, Scissors | Paper, Rock | Scissors, Paper -> Win
    | Paper, Paper | Scissors, Scissors | Rock, Rock -> Draw
  in
  value_of_outcome o + value_of_sign p2

let game_pt2 s1 s2 =
  let p1 = string_of_sign s1 in
  let o = string_of_outcome s2 in
  let p2 =
    match (p1, o) with
    | Rock, Lose | Scissors, Draw | Paper, Win -> Scissors
    | Rock, Draw | Scissors, Win | Paper, Lose -> Rock
    | Rock, Win | Paper, Draw | Scissors, Lose -> Paper
  in
  value_of_outcome o + value_of_sign p2

let run input =
  let rec parse_lines l =
    match l with
    | [] -> []
    | h :: t -> String.split_on_char ' ' h :: parse_lines t
  in
  parse_lines input
  |> List.map (fun l -> game_pt2 (List.nth l 0) (List.nth l 1))
  |> List.fold_left ( + ) 0
