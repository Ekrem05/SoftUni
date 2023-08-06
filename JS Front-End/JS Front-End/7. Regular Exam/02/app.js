window.addEventListener("load", solve);

function solve() {
  const nextBtn = document.querySelector("#next-btn");
  const list = document.querySelector("#preview-list");
  const candidatesList = document.querySelector("#candidates-list");

  const fields = {
    name: document.querySelector("#student"),
    university: document.querySelector("#university"),
    score: document.querySelector("#score"),
  };
  nextBtn.addEventListener("click", addInfo);
  function addInfo() {
    if (!Object.values(fields).some((field) => field.value == "")) {
      const li = createItem("li", null, ["application"]);
      const article = createItem("article");
      createItem("h4", null, null, fields.name.value, article);
      createItem(
        "p",
        null,
        null,
        `University: ${fields.university.value}`,
        article
      );
      createItem("p", null, null, `Score: ${fields.score.value}`, article);
      const editBtn = createItem(
        "button",
        null,
        ["action-btn", "edit"],
        "edit"
      );
      const applyBtn = createItem(
        "button",
        null,
        ["action-btn", "apply"],
        "apply"
      );
      editBtn.addEventListener("click", edit);
      applyBtn.addEventListener("click", apply);

      li.appendChild(article);
      li.appendChild(editBtn);
      li.appendChild(applyBtn);
      list.appendChild(li);
      nextBtn.disabled = true;
      Object.values(fields).forEach((field) => (field.value = ""));
    }
  }
  function edit(e) {
    const item = e.currentTarget.parentElement.children[0];
    fields.name.value = item.children[0].textContent;
    const uni = item.children[1].textContent.split("University: ")[1];
    fields.university.value = uni;
    const score = item.children[2].textContent.split(": ")[1];
    fields.score.value = score;
    nextBtn.disabled = false;
    list.removeChild(item.parentElement);
  }
  function apply(e) {
    const item = e.currentTarget.parentElement.children[0];
    const name = item.children[0].textContent;
    const uni = item.children[1].textContent.split("University: ")[1];
    const score = item.children[2].textContent.split(": ")[1];

    const li = createItem("li", null, ["application"]);
    const article = createItem("article");
    createItem("h4", null, null, name, article);
    createItem("p", null, null, `University: ${uni}`, article);
    createItem("p", null, null, `Score: ${score}`, article);
    li.appendChild(article);
    candidatesList.appendChild(li);
    list.removeChild(item.parentElement);
  }
  function createItem(tag, id, classes, textContent, parent) {
    const item = document.createElement(tag);
    if (textContent) {
      item.textContent = textContent;
    }
    if (classes) {
      item.classList = [...classes].join(" ");
    }
    if (id) {
      item.id = id;
    }

    if (parent) {
      parent.appendChild(item);
    }
    return item;
  }
}
