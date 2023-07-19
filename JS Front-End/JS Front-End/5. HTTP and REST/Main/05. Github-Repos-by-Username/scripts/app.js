function loadRepos() {
  const body = document.querySelector("body");
  const a = document.querySelector("a");

  const username = document.querySelector("#username");
  const request = fetch("https://api.github.com/users/testnakov/repos");
  request
    .then((repos) => repos.json())
    .then((array) => {
      const repos = array.find((repo) => repo.name == username.value);
      const repoUrl = repos.url;
      a.href = repoUrl;
      a.textContent = repos.full_name;
      console.log(repos);
    });
}
