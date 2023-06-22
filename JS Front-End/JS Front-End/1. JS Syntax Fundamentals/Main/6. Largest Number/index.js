function solve(...numbers) {
  let number = numbers.sort((a, b) => b - a)[0];
  console.log(`The largest number is ${number}.`);
}

solve(10, 20, 30, 122, 2);
