window.addEventListener("load", solve);

function solve() {
  const tasks = {};
  const fields = {
    title: document.querySelector("#title"),
    description: document.querySelector("#description"),
    label: document.querySelector("#label"),
    points: document.querySelector("#points"),
    assignee: document.querySelector("#assignee"),
  };

  const buttons = {
    createButton: document.querySelector("#create-task-btn"),
    deleteButton: document.querySelector("#delete-task-btn"),
    hiddenInput: document.querySelector("#task-id"),
    points: document.querySelector("#total-sprint-points"),
  };
  buttons.createButton.addEventListener("click", createTask);
  async function createTask(e) {
    if (Object.values(fields).some((key) => key.value == "")) {
      return;
    }

    const task = {
      id: `task-${Object.values(tasks).length + 1}`,
      title: fields.title.value,
      description: fields.description.value,
      label: fields.label.value,
      points: fields.points.value,
      assignee: fields.assignee.value,
    };
    const lables = {
      feature: "feature",
      "low priority bug": "low-priority",
      "high priority bug": "high-priority",
    };
    const icons = {
      feature: "&#8865;",
      "low priority bug": "&#9737;",
      "high priority bug": "&#9888;",
    };
    tasks[task.id] = task;
    const taskSection = document.querySelector("#tasks-section");
    const article = createItem("article", task.id, ["task-card"], null, null);
    const label = createItem(
      "div",
      null,
      ["task-card-label"],
      lables[task.label.toLowerCase()],
      `${task.label} ${icons[task.label.toLowerCase()]}`,
      article,
      true
    );
    const title = createItem(
      "h3",
      null,
      ["task-card-title"],
      null,
      task.title,
      article
    );
    const description = createItem(
      "p",
      null,
      ["task-card-description"],
      null,
      task.description,
      article
    );
    const points = createItem(
      "div",
      null,
      ["task-card-points"],
      null,
      `Estimated at ${task.title} pts`,
      article
    );
    const assignee = createItem(
      "div",
      null,
      ["task-card-assignee"],
      null,
      `Assigned to: ${task.assignee}`,
      article
    );
    const actions = createItem(
      "div",
      null,
      ["task-card-actions"],
      null,
      null,
      article
    );
    const button = createItem("button", null, null, null, "Delete", actions);
    button.addEventListener("click", deleteProcedure);
    taskSection.appendChild(article);
    Object.values(fields).forEach((el) => (el.value = ""));
    calculatePoints();
  }
  function deleteProcedure(e) {
    const element =
      e.currentTarget.parentElement.parentElement.getAttribute("id");
    fields.title.value = tasks[element].title;
    fields.description.value = tasks[element].description;
    fields.label.value = tasks[element].label;
    fields.points.value = tasks[element].points;
    fields.assignee.value = tasks[element].assignee;

    buttons.deleteButton.disabled = false;
    buttons.createButton.disabled = true;

    fields.title.disabled = true;
    fields.description.disabled = true;
    fields.label.disabled = true;
    fields.points.disabled = true;
    fields.assignee.disabled = true;
    buttons.hiddenInput.value = element;
    buttons.deleteButton.addEventListener("click", deleteTask);
  }
  function deleteTask() {
    console.log(buttons.hiddenInput.value);

    const article = document.getElementById(buttons.hiddenInput.value);
    const tasksSection = document.querySelector("#tasks-section");
    tasksSection.removeChild(article);
    fields.title.value = "";
    fields.description.value = "";
    fields.label.value = "";
    fields.points.value = "";
    fields.assignee.value = "";

    buttons.deleteButton.disabled = true;
    buttons.createButton.disabled = false;

    fields.title.disabled = false;
    fields.description.disabled = false;
    fields.label.disabled = false;
    fields.points.disabled = false;
    fields.assignee.disabled = false;
    delete tasks[buttons.hiddenInput.value];
    calculatePoints();
  }
  function createItem(
    tag,
    id,
    classes,
    additionalClass,
    textContent,
    parent,
    HTML
  ) {
    const item = document.createElement(tag);
    if (HTML || textContent) {
      item.innerHTML = textContent;
    } else if (textContent) {
      item.textContent = textContent;
    }
    if (classes) {
      item.classList = [...classes];
    }
    if (id) {
      item.id = id;
    }
    if (additionalClass) {
      item.classList += ` ${additionalClass}`;
    }

    if (parent) {
      parent.appendChild(item);
    }
    return item;
  }
  function calculatePoints() {
    let result = Object.values(tasks).reduce((obj, curr) => {
      obj += Number(curr.points);
      return obj;
    }, 0);
    buttons.points.textContent = result;
  }
}
