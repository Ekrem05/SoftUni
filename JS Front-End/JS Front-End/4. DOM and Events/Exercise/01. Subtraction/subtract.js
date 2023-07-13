function subtract() {
  const firstNumber = document.querySelector("#firstNumber");
  const secondNumber = document.querySelector("#secondNumber");
  console.log(firstNumber.getAttributeNames());
  firstNumber.removeAttribute("disabled");
  firstNumber.removeAttribute("value");
  secondNumber.removeAttribute("disabled");
  secondNumber.removeAttribute("value");
  function calculate() {
    const result = Number(firstNumber.value - secondNumber.value);
    document.querySelector("#result").textContent = result;
  }

  firstNumber.addEventListener("input", calculate);
  secondNumber.addEventListener("input", calculate);
}
