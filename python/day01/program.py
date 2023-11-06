from pathlib import Path, PurePath


def get_top_one(list):
    list.sort()
    return list[-1]


def get_top_three(list):
    list.sort()
    return sum(list[-3::])


def transform_input(input):
    calories = []
    current_sum = 0

    for value in list(map(lambda x: 0 if x == "\n" else int(x), input)):
        if value == 0:
            calories.append(current_sum)
            current_sum = 0
            continue

        current_sum += value

    return calories


with open(Path.joinpath(Path(__file__).parent, "input.txt"), "r") as input:
    all_results = transform_input(input.readlines())
    part1_results = get_top_one(all_results)
    part2_results = get_top_three(all_results)

    print("Day 01")
    print("------")
    print(f"Part 1: {part1_results}")
    print(f"Part 2: {part2_results}")
