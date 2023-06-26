function sameDigitsAndSum(number) {
  let array = number.toString().split("");
  const digit = array[0];
  let same = true;
  let sum = 0;
  for (i = 0; i <= array.length - 1; i++) {
    if (array[i] !== digit) {
      same = false;
    }
    sum += parseInt(array[i]);
  }
  console.log(same);
  console.log(sum);
}
sameDigitsAndSum(1234);
