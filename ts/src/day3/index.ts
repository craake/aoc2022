function findCommonItems(arr1: string[], arr2: string[], onlyFirst = false): string[] {
  let common = [];

  if (onlyFirst) {
    common = arr2.filter(item => arr1.includes(item));
    console.log(common);

    return common;
  }

  for (let i = 0; i < arr1.length; i++) {
    for (let j = 0; j < arr2.length; j++) {
      if (arr1[i] === arr2[j]) {
        common.push(arr1[i]);
        break;
      }
    }
  }

  return common;
}

function scoreForItem(item: string): number {
  const lookup = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".split("");

  return lookup.indexOf(item) + 1;
}


export default function (input: string): number {
  const lines = input.split('\n');

  for (const line of lines) {
    const arr1 = line.slice(0, line.length / 2).split("");
    const arr2 = line.slice(line.length / 2).split("");

    const common = findCommonItems(arr1, arr2, true);

    for (const item of common) {
      console.log(scoreForItem(item));
    }
  }

  return 69;
}
