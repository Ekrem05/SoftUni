window.addEventListener("load", solve);

function solve() {
  const fields = {
    title: document.querySelector("#task-title"),
    category: document.querySelector("#task-category"),
    content: document.querySelector("#task-content"),
    publishedList: document.querySelector("#published-list"),
    reviewList: document.querySelector("#review-list"),
  };
  const buttons = {
    publishButton: document.querySelector("#publish-btn"),
  };
  buttons.publishButton.addEventListener("click", publishTask);
  function publishTask() {
    if (Object.values(fields).some((key) => key.value == "")) {
      return;
    }
    const task = {
      title: fields.title.value,
      category: fields.category.value,
      content: fields.content.value,
    };
    const li = createItem("li", null, ["rpost"], null, null);
    const article = createItem("article", null, null, null, null);
    const title = createItem("h4", null, null, null, task.title, article);
    const category = createItem(
      "p",
      null,
      null,
      null,
      `Category: ${task.category}`,
      article
    );
    const content = createItem(
      "p",
      null,
      null,
      null,
      `Content: ${task.content}`,
      article
    );

    li.appendChild(article);
    const buttonEdit = createItem(
      "button",
      null,
      ["action-btn", " edit"],
      null,
      "Edit",
      li
    );
    const buttonPost = createItem(
      "button",
      null,
      ["action-btn", " post"],
      null,
      "Post",
      li
    );
    clearFields();
    buttonEdit.addEventListener("click", editTask);
    buttonPost.addEventListener("click", postTask);

    fields.reviewList.appendChild(li);
  }
  function editTask(e) {
    const post = e.currentTarget.parentElement;
    const postArticle = post.children[0];
    const h4 = postArticle.children[0].textContent;
    const category = postArticle.children[1].textContent
      .split(" ")
      .slice(1)
      .join(" ");
    const content = postArticle.children[2].textContent
      .split(" ")
      .slice(1)
      .join(" ");
    fields.title.value = h4;
    fields.category.value = category;
    fields.content.value = content;
    post.parentElement.removeChild(post);
  }
  function postTask(e) {
    const post = e.currentTarget.parentElement;
    const postArticle = post.children[0];
    const h4 = postArticle.children[0].textContent;
    const categoryVal = postArticle.children[1].textContent
      .split(" ")
      .slice(1)
      .join(" ");
    const contentVal = postArticle.children[2].textContent
      .split(" ")
      .slice(1)
      .join(" ");

    const li = createItem("li", null, ["rpost"], null, null);
    const article = createItem("article", null, null, null, null);
    const title = createItem("h4", null, null, null, h4, article);
    const category = createItem(
      "p",
      null,
      null,
      null,
      `Category: ${categoryVal}`,
      article
    );
    const content = createItem(
      "p",
      null,
      null,
      null,
      `Content: ${contentVal}`,
      article
    );

    li.appendChild(article);
    fields.publishedList.appendChild(li);
    post.parentElement.removeChild(post);
  }
  function clearFields() {
    fields.title.value = "";
    fields.category.value = "";
    fields.content.value = "";
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
