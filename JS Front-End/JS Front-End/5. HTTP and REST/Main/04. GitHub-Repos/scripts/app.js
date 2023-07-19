function loadRepos() {
  const body = document.querySelector("body");
  const request = fetch("https://api.github.com/users/testnakov/repos");
  request
    .then((repos) => repos.json())
    .then((array) => {
      const div = document.querySelector("#res");
      array.forEach((element) => {
        const repo = document.createElement("p");
        repo.textContent = JSON.stringify(element);
        div.appendChild(repo);
      });
    });
}
