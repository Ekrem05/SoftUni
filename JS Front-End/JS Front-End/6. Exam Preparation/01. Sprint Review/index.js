function solve(array) {
  const n = Number(array[0]);
  const entries = array.slice(1, n + 1);
  const commands = array.slice(n + 1);

  const tasks = entries.reduce((obj, current) => {
    const [asignee, taskId, title, status, estimatedPoints] =
      current.split(":");
    if (!obj[asignee]) {
      obj[asignee] = [];
    }
    obj[asignee].push({
      taskId,
      title,
      status,
      estimatedPoints,
    });

    return obj;
  }, {});

  commands.forEach((element) => {
    let tokens = element.split(":");
    let action = tokens[0];
    if (action === "Add New") {
      const assigneeName = tokens[1];
      if (tasks.hasOwnProperty(assigneeName)) {
        let info = tokens.slice(2);
        tasks[assigneeName].push({
          taskId: info[0],
          title: info[1],
          status: info[2],
          estimatedPoints: info[3],
        });
      } else {
        console.log(`Assignee ${assigneeName} does not exist on the board!`);
      }
    } else if (action === "Change Status") {
      const assigneeName = tokens[1];
      if (tasks.hasOwnProperty(assigneeName)) {
        const taskIdToFind = tokens[2];
        const newStatus = tokens[3];

        const assigment = tasks[assigneeName].find(
          (array) => array.taskId === taskIdToFind
        );
        if (!assigment) {
          console.log(
            `Task with ID ${taskIdToFind} does not exist for ${assigneeName}!`
          );
        } else {
          assigment.status = newStatus;
        }
      } else {
        console.log(`Assignee ${assigneeName} does not exist on the board!`);
      }
    } else if (action === "Remove Task") {
      const assigneeName = tokens[1];
      if (tasks.hasOwnProperty(assigneeName)) {
        const index = tokens[2];
        if (index < 0 || index > tasks[assigneeName].length) {
          console.log("Index is out of range!");
        }
        tasks[assigneeName].splice(index, 1);
      } else {
        console.log(`Assignee ${assigneeName} does not exist on the board!`);
      }
    }
  });
  const points = {
    toDo: 0,
    progress: 0,
    review: 0,
    done: 0,
  };
  Object.keys(tasks).forEach((asignee) => {
    let arrays = tasks[asignee];
    arrays.forEach((array) => {
      if (array.status == "ToDo") {
        points.toDo += Number(array.estimatedPoints);
      } else if (array.status == "In Progress") {
        points.progress += Number(array.estimatedPoints);
      } else if (array.status == "Code Review") {
        points.review += Number(array.estimatedPoints);
      } else if (array.status == "Done") {
        points.done += Number(array.estimatedPoints);
      }
    });
  });
  console.log(`ToDo: ${points.toDo}pts`);
  console.log(`In Progress: ${points.progress}pts`);
  console.log(`Code Review: ${points.review}pts`);
  console.log(`Done Points: ${points.done}pts`);
  if (points.done >= points.review + points.progress + points.toDo) {
    console.log("Sprint was successful!");
  } else {
    console.log("Sprint was unsuccessful...");
  }
}
solve([
  "5",
  "Kiril:BOP-1209:Fix Minor Bug:ToDo:3",
  "Mariya:BOP-1210:Fix Major Bug:In Progress:3",
  "Peter:BOP-1211:POC:Code Review:5",
  "Georgi:BOP-1212:Investigation Task:Done:2",
  "Mariya:BOP-1213:New Account Page:In Progress:13",
  "Add New:Kiril:BOP-1217:Add Info Page:In Progress:5",
  "Change Status:Peter:BOP-1290:ToDo",
  "Remove Task:Mariya:1",
  "Remove Task:Joro:1);",
]);
