function loadCommits() {
  const username = document.querySelector("#username");
  const repo = document.querySelector("#repo");
  const commitsList = document.querySelector("#commits");

  const request = fetch(
    `https://api.github.com/repos/${username.value}/${repo.value}/commits`
  );
  request
    .then((repos) => repos.json())
    .then((commits) => {
      commits.forEach((commit) => {
        const listItem = document.createElement("li");
        listItem.textContent = `${commit.commit.author.name} ${commit.commit.author.date}`;
        commitsList.appendChild(listItem);
      });
    });
}
