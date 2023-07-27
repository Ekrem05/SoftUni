function solve() {
  const buttons = {
    loadButton: document.querySelector("#load-course"),
    addButton: document.querySelector("#add-course"),
    editCourseBtn: document.querySelector("#edit-course"),
  };
  buttons.editCourseBtn.disabled = true;
  buttons.editCourseBtn.addEventListener("click", postEditedCourse);
  const selectors = {
    listOfCourses: document.querySelector("#list"),
  };
  const input = {
    title: document.querySelector("#course-name"),
    type: document.querySelector("#course-type"),
    description: document.querySelector("#description"),
    teacher: document.querySelector("#teacher-name"),
  };
  buttons.loadButton.addEventListener("click", loadCourses);
  buttons.addButton.addEventListener("click", addCourse);
  let allCourses = {};
  let buttonIdToEdit;
  async function loadCourses() {
    allCourses = await (
      await fetch("http://localhost:3030/jsonstore/tasks/")
    ).json();
    selectors.listOfCourses.innerHTML = "";
    Object.values(allCourses).forEach((course) => {
      const containerDiv = createItem("div", null, ["container"]);
      const title = createItem(
        "h2",
        null,
        null,
        null,
        course.title,
        containerDiv
      );
      const teacher = createItem(
        "h3",
        null,
        null,
        null,
        course.teacher,
        containerDiv
      );
      const type = createItem(
        "h3",
        null,
        null,
        null,
        course.type,
        containerDiv
      );
      const description = createItem(
        "h4",
        null,
        null,
        null,
        course.description,
        containerDiv
      );
      const editBtn = createItem(
        "button",
        `${course._id}`,
        ["edit-btn"],
        null,
        "Edit Course",
        containerDiv
      );
      const finishBtn = createItem(
        "button",
        `${course._id}`,
        ["finish-btn"],
        null,
        "Finish Course",
        containerDiv
      );
      editBtn.addEventListener("click", editCourse);
      finishBtn.addEventListener("click", deleteCourse);

      selectors.listOfCourses.appendChild(containerDiv);
    });
  }
  async function addCourse() {
    const course = {
      title: input.title.value,
      type: input.type.value,
      description: input.description.value,
      teacher: input.teacher.value,
    };
    await fetch("http://localhost:3030/jsonstore/tasks/", {
      method: "POST",
      body: JSON.stringify(course),
    });
    loadCourses();
    Object.values(input).forEach((input) => (input.value = ""));
  }
  async function editCourse(e) {
    const courseToEdit = allCourses[e.currentTarget.getAttribute("id")];

    input.title.value = allCourses[courseToEdit._id].title;
    input.type.value = allCourses[courseToEdit._id].type;
    input.description.value = allCourses[courseToEdit._id].description;
    input.teacher.value = allCourses[courseToEdit._id].teacher;
    buttons.addButton.disabled = true;
    buttons.editCourseBtn.disabled = false;
    buttonIdToEdit = courseToEdit._id;
  }
  async function postEditedCourse() {
    const editedCourse = {
      _id: buttonIdToEdit,
      title: input.title.value,
      type: input.type.value,
      description: input.description.value,
      teacher: input.teacher.value,
    };
    await await fetch(
      `http://localhost:3030/jsonstore/tasks/${buttonIdToEdit}`,
      {
        method: "PUT",
        body: JSON.stringify(editedCourse),
      }
    );
    Object.values(input).forEach((input) => (input.value = ""));
    loadCourses();
    buttons.addButton.disabled = false;
    buttons.editCourseBtn.disabled = true;
  }
  async function deleteCourse(e) {
    const courseToDelete = allCourses[e.currentTarget.getAttribute("id")];
    console.log(courseToDelete._id);
    await fetch(`http://localhost:3030/jsonstore/tasks/${courseToDelete._id}`, {
      method: "DELETE",
    });
    await loadCourses();
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
      item.classList = [...classes].join(" ");
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
}
solve();
