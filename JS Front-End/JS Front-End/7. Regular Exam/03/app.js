function solve() {
  const loadBtn = document.querySelector("#load-vacations");
  loadBtn.addEventListener("click", loadData);
  const list = document.querySelector("#list");
  const addVacBtn = document.querySelector("#add-vacation");
  const editVacBtn = document.querySelector("#edit-vacation");
  editVacBtn.addEventListener("click", putEditedVac);
  let itemtoEditId;
  const input = {
    name: document.querySelector("#name"),
    days: document.querySelector("#num-days"),
    date: document.querySelector("#from-date"),
  };
  addVacBtn.addEventListener("click", addVacation);
  async function loadData() {
    console.log("here");
    list.innerHTML = "";
    const req = await fetch("http://localhost:3030/jsonstore/tasks/");
    const data = await req.json();
    Object.values(data).forEach((input) => {
      console.log(input);
      const card = createItem("div", null, ["container"]);
      createItem("h2", null, null, input.name, card);
      createItem("h3", null, null, input.date, card);
      createItem("h3", null, null, input.days, card);
      const changeBtn = createItem(
        "button",
        null,
        ["change-btn", input._id],
        "Change",
        card
      );
      changeBtn.addEventListener("click", editVacation);
      const doneBtn = createItem(
        "button",
        null,
        ["change-btn", input._id],
        "Done",
        card
      );
      doneBtn.addEventListener("click", deleteVac);

      list.appendChild(card);
    });
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
  async function addVacation() {
    const vacation = {
      name: input.name.value,
      days: input.days.value,
      date: input.date.value,
    };
    await fetch("http://localhost:3030/jsonstore/tasks/", {
      method: "POST",
      body: JSON.stringify(vacation),
    });
    Object.values(input).forEach((input) => (input.value = ""));
    await loadData();
  }
  async function editVacation(e) {
    itemtoEditId = e.currentTarget.classList[1];
    input.name.value = e.currentTarget.parentElement.children[0].textContent;
    input.date.value = e.currentTarget.parentElement.children[1].textContent;
    input.days.value = e.currentTarget.parentElement.children[2].textContent;
    editVacBtn.disabled = false;
    addVacBtn.disabled = true;
  }
  async function putEditedVac() {
    const vacation = {
      _id: itemtoEditId,
      name: input.name.value,
      date: input.date.value,
      days: input.days.value,
    };
    await await fetch(`http://localhost:3030/jsonstore/tasks/${itemtoEditId}`, {
      method: "PUT",
      body: JSON.stringify(vacation),
    });
    await loadData();
    Object.values(input).forEach((input) => (input.value = ""));

    editVacBtn.disabled = true;
    addVacBtn.disabled = false;
  }
  async function deleteVac(e) {
    const id = e.currentTarget.classList[1];
    await fetch(`http://localhost:3030/jsonstore/tasks/${id}`, {
      method: "DELETE",
      body: undefined,
    });
    await loadData();
  }
}
solve();
