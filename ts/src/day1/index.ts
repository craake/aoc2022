export default function(input: string) {
  const entries: number[] = input.split("\n").map(l => parseInt(l));
  let calories: number[] = [];
  let currentCal = 0;

  for (let i = 0; i <= entries.length; ++i) {
    const e = entries[i];

    if (Number.isNaN(e) || i == entries.length) {
      calories.push(currentCal);
      currentCal = 0;
      continue;
    }

    currentCal += e;
  }

  return calories
    .sort((a, b) => a - b)
    .slice(-3)
    .reduce((acc, cur) => acc + cur, 0);
}
