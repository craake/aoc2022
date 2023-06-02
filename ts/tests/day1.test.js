import day1 from '../src/day1/index';

test('result is correct with clean input', () => {
  const input = "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000";
  expect(day1(input)).toBe(45000);
});

test('result is correct with dirty input', () => {
  const input = "xxxx\n1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000\nyyyy\n\n\n";
  expect(day1(input)).toBe(45000);
});
