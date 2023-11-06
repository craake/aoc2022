from pathlib import Path
import string


def char_value(c: str) -> int:
    vals = list(string.ascii_lowercase + string.ascii_uppercase)
    return vals.index(c) + 1


def common_chars(str1: str, str2: str) -> list[str]:
    common = []
    for x in str1:
        for y in str2:
            if x == y and not x in common:
                common.append(x)
    return common


def common_in_groups(
    input: list[str], current_group: int, group_size: int, sum: int = 0
):
    frm = current_group - 1
    to = frm + 3
    group = input[frm:to]
    common = common_chars(common_chars(group[0], group[1]), group[2])

    if len(common) > 0:
        for item in common:
            sum += char_value(item)
    try:
        return common_in_groups(input, current_group + group_size, group_size, sum)
    except:
        return sum


with open(Path.joinpath(Path(__file__).parent, "input.txt")) as input:
    lines = input.read().split("\n")
    part1_sum = 0
    part2_sum = 0

    for line in lines:
        half = len(line) // 2
        pairs = (line[0:half], line[half:])
        common = common_chars(pairs[0], pairs[1])
        for item in common:
            part1_sum += char_value(item)

    part2_sum = common_in_groups(lines, 1, 3)

    print("Day 3\n-----")
    print(f"Part 1: {part1_sum}")
    print(f"Part 2: {part2_sum}")
    print("")
