function addItem() {
  const element = document.createElement("li");
  const elementText = document.querySelector("#newItemText").value;
  element.textContent = elementText;
  console.log(element.textContent);
  document.querySelector("ul").appendChild(element);
}
