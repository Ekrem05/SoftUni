// TODO:
function attachEvents() {
  document.querySelector("#load-board-btn").addEventListener("click", getTasks);
  document
    .querySelector("#create-task-btn")
    .addEventListener("click", addTasks);
  let tasks = {};
  const taskSelectors = {
    ToDo: document.querySelector("#todo-section .task-list"),
    "In Progress": document.querySelector("#in-progress-section .task-list"),
    "Code Review": document.querySelector("#code-review-section .task-list"),
    Done: document.querySelector("#done-section .task-list"),
  };
  const status = {
    ToDo: "Move to In Progress",
    "In Progress": "Move to Code Review",
    "Code Review": "Move to Done",
    Done: "Close",
  };
  const statusTransfer = {
    ToDo: "In Progress",
    "In Progress": "Code Review",
    "Code Review": "Done",
    Done: "Close",
  };
  const inputValues = {
    title: document.querySelector("#title"),
    description: document.querySelector("#description"),
    status: "ToDo",
  };
  async function getTasks() {
    tasks = await (
      await fetch("http://localhost:3030/jsonstore/tasks/")
    ).json();
    Object.values(taskSelectors).forEach((task) => {
      task.innerHTML = "";
    });
    Object.values(tasks).forEach((task) => {
      const section = taskSelectors[task.status];
      const listItem = document.createElement("li");
      const h3 = document.createElement("h3");
      const p = document.createElement("p");
      const button = document.createElement("button");
      listItem.classList = "task";
      h3.textContent = task.title;
      p.textContent = task.description;
      button.addEventListener("click", moveTask);
      button.textContent = status[task.status];
      button.id = task._id;
      listItem.appendChild(h3);
      listItem.appendChild(p);
      listItem.appendChild(button);
      section.appendChild(listItem);
    });
  }
  async function addTasks() {
    const newTask = {
      title: inputValues.title.value,
      description: inputValues.description.value,
      status: inputValues.status,
    };
    fetch("http://localhost:3030/jsonstore/tasks/", {
      method: "Post",
      body: JSON.stringify(newTask),
    });
    getTasks();
    Object.values(inputValues).forEach((input) => (input.value = ""));
  }
  async function moveTask(e) {
    const taskToMove = tasks[e.currentTarget.getAttribute("id")];
    if (statusTransfer[taskToMove.status] == "Close") {
      await fetch(`http://localhost:3030/jsonstore/tasks/${taskToMove._id}`, {
        method: "DELETE",
        body: undefined,
      });
    } else {
      await fetch(`http://localhost:3030/jsonstore/tasks/${taskToMove._id}`, {
        method: "PATCH",
        body: JSON.stringify({
          ...taskToMove,
          status: statusTransfer[taskToMove.status],
        }),
      });
    }
    getTasks();
  }
}
attachEvents();
