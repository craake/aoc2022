import day2 from '../src/day2/index';

// test('outcome strategy', () => {
//   const input = "A Y\nB X\nC Z\n";
//   const result = day2(input);

//   expect(result).toBe(15);
// });

test('player move strategy', () => {
  const input = "A Y\nB X\nC Z";
  const result = day2(input);

  expect(result).toBe(12);
});
