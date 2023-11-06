from enum import Enum
from functools import reduce
from pathlib import Path


class GameType(Enum):
    CALCULATE_OUTCOME = 1
    CALCULATE_MOVE = 2


class Outcome(Enum):
    LOSS = 0
    DRAW = 3
    WIN = 6

    def from_str(s: str):
        match s:
            case "X":
                return Outcome(Outcome.LOSS)
            case "Y":
                return Outcome(Outcome.DRAW)
            case "Z":
                return Outcome(Outcome.WIN)
            case _:
                raise f"{s} is not a valid string for Outcome"


class Shape(Enum):
    ROCK = 1
    PAPER = 2
    SCISSORS = 3

    @staticmethod
    def from_str(s: str):
        match s:
            case "A" | "X":
                return Shape(Shape.ROCK)
            case "B" | "Y":
                return Shape(Shape.PAPER)
            case "C" | "Z":
                return Shape(Shape.SCISSORS)
            case _:
                raise f"{s} is not a valid string for Shape"

    def can_beat(self, shape) -> bool:
        match (self, shape):
            case (Shape.ROCK, Shape.SCISSORS) | (Shape.PAPER, Shape.ROCK) | (
                Shape.SCISSORS,
                Shape.PAPER,
            ):
                return True
            case _:
                return False

    def beats(self):
        match self:
            case Shape.ROCK:
                return Shape.SCISSORS
            case Shape.PAPER:
                return Shape.ROCK
            case Shape.SCISSORS:
                return Shape.PAPER
            case _:
                raise f"Missing a rule for {self.type}"

    def gets_beaten_by(self):
        match self:
            case Shape.ROCK:
                return Shape.PAPER
            case Shape.PAPER:
                return Shape.SCISSORS
            case Shape.SCISSORS:
                return Shape.ROCK
            case _:
                raise f"Missing a rule for {self.type}"


class Game:
    def __init__(self) -> None:
        raise RuntimeError(
            "Call init_calculate_outcome_mode() or init_calculate_move_mode()"
        )

    @classmethod
    def init_calculate_outcome_mode(cls, player1: Shape, player2: Shape):
        instance = cls.__new__(cls)
        instance._type = GameType.CALCULATE_OUTCOME
        instance._player1 = player1
        instance._player2 = player2

        return instance

    @classmethod
    def init_calculate_move_mode(cls, player1: Shape, outcome: Outcome):
        instance = cls.__new__(cls)
        instance._type = GameType.CALCULATE_MOVE
        instance._player1 = player1
        instance._outcome = outcome

        return instance

    def __run_calculate_move_mode(self) -> int:
        if self._outcome is Outcome.DRAW:
            self._player2 = self._player1
        elif self._outcome is Outcome.WIN:
            self._player2 = self._player1.gets_beaten_by()
        else:
            self._player2 = self._player1.beats()

        return self._outcome.value + self._player2.value

    def __run_calculate_outcome_mode(self) -> int:
        if self._player1 == self._player2:
            self._outcome = Outcome.DRAW
        elif self._player1.can_beat(self._player2):
            self._outcome = Outcome.WIN
        else:
            self._outcome = Outcome.LOSS

        return self._outcome.value + self._player1.value

    def run(self) -> int:
        match self._type:
            case GameType.CALCULATE_OUTCOME:
                return self.__run_calculate_outcome_mode()
            case GameType.CALCULATE_MOVE:
                return self.__run_calculate_move_mode()
            case _:
                raise RuntimeError("Invalid game type")


def play_outcome_mode(line: str) -> int:
    shapes = line.replace("\n", "").split(" ")
    game = Game.init_calculate_outcome_mode(
        Shape.from_str(shapes[1]), Shape.from_str(shapes[0])
    )

    return game.run()


def play_opponent_move_mode(line: str) -> int:
    line = line.replace("\n", "").split(" ")
    game = Game.init_calculate_move_mode(
        Shape.from_str(line[0]), Outcome.from_str(line[1])
    )

    return game.run()


with open(Path.joinpath(Path(__file__).parent, "input.txt"), "r") as input:
    inputs = input.readlines()
    part1_result = sum(list(map(play_outcome_mode, inputs)))
    part2_result = sum(list(map(play_opponent_move_mode, inputs)))

    print("Day 2\n-----")
    print(f"Part 1: {part1_result}")
    print(f"Part 2: {part2_result}")
    print("")
