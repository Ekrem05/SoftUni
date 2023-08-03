window.addEventListener("load", solve);

function solve() {
  const addButton = document.querySelector("#add-btn");
  addButton.type = "";
  const songs = [];
  const songContainer = document.querySelector(".all-hits-container");
  const savedSongsContainer = document.querySelector(".saved-container");

  const likesSection = document.querySelector(".likes");

  addButton.addEventListener("click", addSong);
  function addSong(e) {
    e.preventDefault();
    const song = {
      id: songs.length,
      genre: document.querySelector("#genre"),
      name: document.querySelector("#name"),
      author: document.querySelector("#author"),
      date: document.querySelector("#date"),
    };
    if (Object.values(song).some((value) => value.value == "")) {
      return;
    }
    const songCard = createItem("div", null, ["hits-info"]);
    const img = createItem("img", null, null, null, null);
    img.src = "./static/img/img.png";
    songCard.appendChild(img);

    createItem("h2", null, null, `Genre: ${song.genre.value}`, songCard);
    createItem("h2", null, null, `Name: ${song.name.value}`, songCard);
    createItem("h2", null, null, `Author: ${song.author.value}`, songCard);
    createItem("h3", null, null, `Date: ${song.date.value}`, songCard);
    const savebtn = createItem(
      "button",
      null,
      ["save-btn"],
      `Save song`,
      songCard
    );
    const likebtn = createItem(
      "button",
      null,
      ["like-btn"],
      `Like song`,
      songCard
    );
    const deletebtn = createItem(
      "button",
      null,
      ["delete-btn"],
      `Delete`,
      songCard
    );
    savebtn.addEventListener("click", saveSong);
    likebtn.addEventListener("click", likeSong);
    deletebtn.addEventListener("click", deleteSong);

    songs.push[song];
    Object.values(song).forEach((song) => (song.value = ""));
    songContainer.appendChild(songCard);
  }
  function likeSong(e) {
    let likes = Number(likesSection.children[0].textContent.split(": ")[1]);
    likes += 1;
    likesSection.children[0].textContent = `Total Likes: ${likes}`;
    e.currentTarget.disabled = true;
  }
  function saveSong(e) {
    const card = e.currentTarget.parentElement;
    songContainer.removeChild(card);
    const genre = card.children[1];
    const name = card.children[2];
    const author = card.children[3];
    const date = card.children[4];
    const songCard = createItem("div", null, ["hits-info"]);
    const img = createItem("img", null, null, null, null);
    img.src = "./static/img/img.png";
    songCard.appendChild(img);
    createItem("h2", null, null, `${genre.textContent}`, songCard);
    createItem("h2", null, null, `${name.textContent}`, songCard);
    createItem("h2", null, null, `${author.textContent}`, songCard);
    createItem("h3", null, null, `${date.textContent}`, songCard);

    const deletebtn = createItem(
      "button",
      null,
      ["delete-btn"],
      `Delete`,
      songCard
    );
    deletebtn.addEventListener("click", deleteSong);

    savedSongsContainer.appendChild(songCard);
  }
  function deleteSong(e) {
    const card = e.currentTarget.parentElement;
    const section = card.parentElement;
    section.removeChild(card);
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
