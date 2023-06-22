function solve(array) {
  let even = 0;
  let odd = 0;

  for (i = 0; i <= array.length - 1; i++) {
    if (array[i] % 2 == 0) {
      even += array[i];
    } else {
      odd += array[i];
    }
  }
  let result = even - odd;
  console.log(result);
}

solve([3, 5, 7, 9]);
