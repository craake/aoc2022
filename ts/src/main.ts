import { createInterface } from 'node:readline';
import { resolve } from 'node:path';
import { readFile, access } from 'node:fs';

const inq = createInterface({
  input: process.stdin,
  output: process.stdout
});

inq.question('Which day would you like to run? ', day => {
  run(day);
  inq.close();
});

function run(day: string): void {
  const basePath = resolve(`./dist`);
  const execPath = resolve(`${basePath}/day${day}/index.js`);
  access(execPath, (err) => {
    if (err) {
      console.error(`Day ${day} not implemented yet :(`);
      return;
    }

    import(execPath).then(imported => {
      readFile(`${basePath}/inputs/day${day}`, (err, data) => {
        if (err) {
          console.error(err);
          return;
        }

        console.log(`\n*** Day ${day} ***\n`);

        const result = imported.default(data.toString());
        console.log(result);
      });
    });
  });
}
