let input = Input_reader.string_list_of_file "day1" in
Day1.run input |> Printf.printf "Day 1 result:\n%d\n";

let input = Input_reader.string_list_of_file "day2" in
Day2.run input |> Printf.printf "Day 2 result:\n%d\n"
