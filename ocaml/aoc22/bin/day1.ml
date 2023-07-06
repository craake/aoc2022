(* First try - no idea, but looks too complicated *)

(* let top_n n calories =
     let rec first_n lst n acc =
       match lst with
       | h :: t when List.length acc < n -> first_n t n (h :: acc)
       | _ :: _ when List.length acc = n -> acc
       | _ :: _ -> acc
       | [] -> []
     in
     let ordered_calories = calories |> List.sort compare |> List.rev in
     first_n ordered_calories n []

   let top_calories input n =
     Str.split (Str.regexp "\n\n") input
     |> List.map (fun s -> Str.split (Str.regexp "\n") s)
     |> List.map (fun group -> List.map (fun x -> int_of_string x) group)
     |> List.map (fun group -> List.fold_left ( + ) 0 group)
     |> top_n n |> List.fold_left ( + ) 0 *)

(* Looks a bit better... Not great not terrible, I guess *)

let rec sum_until_empty (acc : int) (lst : string list) : int list =
  match lst with
  | [] -> [ acc ]
  | h :: t ->
      if h = "" then acc :: sum_until_empty 0 t
      else sum_until_empty (acc + int_of_string h) t

let rec sum_first lst acc k n =
  match lst with
  | h :: t -> if k < n then sum_first t (acc + h) (k + 1) n else acc
  | _ -> acc

let run input =
  let rec sum_first_3 lst acc k =
    match lst with
    | h :: t -> if k < 3 then sum_first_3 t (acc + h) (k + 1) else acc
    | _ -> acc
  in
  let r = input |> sum_until_empty 0 |> List.sort compare |> List.rev in
  sum_first_3 r 0 0
