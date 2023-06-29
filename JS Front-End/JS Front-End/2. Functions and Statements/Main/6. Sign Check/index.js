function signCheck(...numbers) {
  function countNegativeSymbols(...numbers) {
    let count = 0;
    for (i = 0; i < numbers.length; i++) {
      if (numbers[i] < 0) {
        count++;
      }
    }

    return count;
  }
  if (countNegativeSymbols(...numbers) % 2 != 0) return "Negative";
  else return "Positive";
}
console.log(signCheck(-51, 1, 1));
