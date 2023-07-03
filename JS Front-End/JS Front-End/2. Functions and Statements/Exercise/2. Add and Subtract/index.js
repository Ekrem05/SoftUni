function subtract(...numbers) {
  function sum(...numbers) {
    return numbers[0] + numbers[1];
  }
  let result = sum(...numbers);
  return result - numbers[2];
}

console.log(subtract(1, 17, 30));
