function addItem() {
  const element = document.createElement("li");
  const deleteElement = document.createElement("a");
  deleteElement.textContent = "[Delete]";
  deleteElement.href = "#";
  deleteElement.addEventListener("click", (e) =>
    e.target.parentElement.remove()
  );
  const elementText = document.querySelector("#newItemText").value;
  element.textContent = elementText;
  console.log(element.textContent);
  element.appendChild(deleteElement);
  document.querySelector("ul").appendChild(element);
}
