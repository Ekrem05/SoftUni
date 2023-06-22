function solve(number, array) {
  let result = [];
  for (i = 0; i < number; i++) {
    result.push(array[i]);
  }
  result = result.reverse();
  console.log(result.join(" "));
}

solve(4, [-1, 20, 99, 5]);
