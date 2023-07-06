let string_list_of_file file =
   let rec read_lines ic lst =
     try
       let line = input_line ic in
       read_lines ic (line :: lst)
     with End_of_file ->
       close_in ic;
       lst
   in
   let ic = open_in file in
   read_lines ic []

let string_of_file file =
  let rec read_lines ic s =
    try
      let line = input_line ic in
      read_lines ic (s ^ line ^ "\n")
    with End_of_file ->
      close_in ic;
      s
  in
  let ic = open_in file in
  read_lines ic ""
