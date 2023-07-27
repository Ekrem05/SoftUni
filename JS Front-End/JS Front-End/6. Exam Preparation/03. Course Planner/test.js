document.body.innerHTML = `
<main>
        <section id="form-section">
            <h1>Sprint Planning</h1>
            <form id="create-task-form">
                <input id="task-id" type="hidden" />
                <div class="form-control">
                    <label for="title">Title:</label>
                    <input id="title" type="text" placeholder="Task title..." />
                </div>
                <div class="form-control">
                    <label for="description">Description:</label>
                    <textarea id="description" placeholder="Task description..."></textarea>
                </div>
                <div class="form-control">
                    <label for="label">Label:</label>
                    <select id="label">
                        <option value="Feature">
                            Feature
                        </option>
                        <option value="Low Priority Bug">Low Priority Bug</option>
                        <option value="High Priority Bug">High Priority Bug</option>
                    </select>
                </div>
                <div class="form-control">
                    <label for="points">Estimation Points:</label>
                    <input id="points" type="number" placeholder="Task estimation points..." />
                </div>
                <div class="form-control">
                    <label for="assignee">Assignee:</label>
                    <input id="assignee" type="text" placeholder="Task assignee..." />
                </div>
                <div class="form-control">
                    <input type="button" id="create-task-btn" value="Create Task" />
                </div>
                <div class="form-control">
                    <input type="button" id="delete-task-btn" disabled value="Delete Task" />
                </div>
            </form>
        </section>
        <section id="tasks-section">
            <h1>New Sprint Tasks</h1>
            <p id="total-sprint-points">
                Total Points 0pts
            </p>
        </section>
    </main>
    <script src="./app.js"></script>
`;
result();
const makeTask = {
  title: () => document.getElementById("title"),
  description: () => document.getElementById("description"),
  label: () => document.getElementById("label"),
  points: () => document.getElementById("points"),
  assignee: () => document.getElementById("assignee"),
  createTask: () => document.getElementById("create-task-btn"),
  deleteTask: () => document.getElementById("delete-task-btn"),
};
makeTask.title().value = "Create Subscriptions Page";
makeTask.description().value = "Create Subscriptions Page for our business";
makeTask.label().value = "Low Priority Bug";
makeTask.points().value = "3";
makeTask.assignee().value = "Mariya Borisova";

makeTask.createTask().click();
expect(
  document.querySelector("#tasks-section > article > .task-card-label")
    .textContent
).to.equal("Low Priority Bug ☉", "Label is invalid!");
