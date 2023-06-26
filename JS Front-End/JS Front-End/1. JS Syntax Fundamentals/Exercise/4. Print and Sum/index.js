function printAndSum(start, end) {
  let array = [];
  let sum = 0;
  for (i = start; i <= end; i++) {
    array.push(i);
    sum += i;
  }
  console.log(array.join(" "));
  console.log(`Sum: ${sum}`);
}
printAndSum(50, 60);
