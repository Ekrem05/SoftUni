function extractText() {
  const arrayOfText = Array.from(document.querySelectorAll("li"));
  const textArea = document.getElementById("result");
  textArea.value = arrayOfText.map((element) => element.textContent).join("\n");
}
