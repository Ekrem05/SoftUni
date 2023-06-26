function sumDigits(number) {
  let array = number.toString().split("");
  let sum = 0;
  for (i = 0; i <= array.length - 1; i++) {
    sum += parseInt(array[i]);
  }
  console.log(sum);
}
sumDigits(245678);
