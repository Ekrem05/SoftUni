function calc() {
  const firstValue = document.getElementById("num1");
  const secondValue = document.getElementById("num2");
  const sum = Number(firstValue.value) + Number(secondValue.value);
  document.getElementById("sum").value = sum;
}
