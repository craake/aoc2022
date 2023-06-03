enum Sign {
  Rock = 1,
  Paper = 2,
  Scissors = 3
}

enum Outcome {
  Loss = 0,
  Draw = 3,
  Win = 6
}

type GameStrategy = {
  (game: Game): void;
}

type Rule = {
  beats: Sign[],
  beaten_by: Sign[]
};

type Player = {
  sign: Sign
}

const signFromString = (s: string): Sign => {
  switch (s) {
    case "A":
    case "X":
      return Sign.Rock;
    case "B":
    case "Y":
      return Sign.Paper;
    case "C":
    case "Z":
      return Sign.Scissors;
    default:
      throw "Invalid sign";
  }
}

const strategyDecideOutcome: GameStrategy = (game: Game) => {
  if (game.player1.sign === game.player2.sign) {
    game.outcome = Outcome.Draw;
  } else if (Game.rules(game.player2.sign).beats.includes(game.player1.sign)) {
    game.outcome = Outcome.Win;
  } else {
    game.outcome = Outcome.Loss;
  }
}

const strategyDecideMove: GameStrategy = (game: Game) => {
  if (game.outcome === Outcome.Draw) {
    game.player2 = game.player1;
  } else if (game.outcome === Outcome.Win) {
    game.player2 = { sign: Game.rules(game.player1.sign).beaten_by[0] };
  } else {
    game.player2 = { sign: Game.rules(game.player1.sign).beats[0] };
  }
}
const outcomeFromString = (s: string): Outcome => {
  switch (s) {
    case "X":
      return Outcome.Loss;
    case "Y":
      return Outcome.Draw;
    case "Z":
      return Outcome.Win;
    default:
      throw "Invalid outcome";
  }
}

class Game {
  strategy: GameStrategy;
  player1: Player;
  player2?: Player;
  score?: number;
  outcome?: Outcome;

  constructor(args: { strategy: GameStrategy, player1: Player, player2?: Player, outcome?: Outcome }) {
    this.strategy = args.strategy;
    this.player1 = args.player1;
    this.player2 = args.player2;
    this.outcome = args.outcome;
  }

  play() {
    this.strategy(this);
    this.score = this.player2.sign + this.outcome;
  }


  static rules(sign: Sign): Rule {
    switch (sign) {
      case Sign.Rock:
        return {
          beats: [Sign.Scissors],
          beaten_by: [Sign.Paper]
        };
      case Sign.Paper:
        return {
          beats: [Sign.Rock],
          beaten_by: [Sign.Scissors]
        };
      case Sign.Scissors:
        return {
          beats: [Sign.Paper],
          beaten_by: [Sign.Rock]
        };
    }
  }
}

export default function(input: string): number {
  const turns = input
    .split("\n")
    .filter(line => line !== "")
    .map(entry => entry.split(" "));

  const scores = turns.map((moves) => {
    // Part 1
    // const game = new Game({
    //   strategy: strategyDecideOutcome,
    //   player1: { sign: signFromString(moves[0]) },
    //   player2: { sign: signFromString(moves[1]) }
    // });

    // Part 2
    const game = new Game({
      strategy: strategyDecideMove,
      player1: { sign: signFromString(moves[0]) },
      outcome: outcomeFromString(moves[1])
    });

    game.play();

    return game.score;
  });

  return scores.reduce((acc, score) => acc + score, 0);
}
