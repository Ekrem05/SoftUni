function lockedProfile() {
  const arrayOfButtons = Array.from(document.querySelectorAll("button"));
  arrayOfButtons.forEach((button) => {
    button.addEventListener("click", () => {
      const parent = button.parentElement;
      const hidden = parent.children[9];
      const locked = parent.children[4];
      if (button.textContent == "Show more") {
        if (locked.checked == true) {
          hidden.style.display = "block";
          button.textContent = "Hide it";
        }
      } else {
        if (locked.checked == true) {
          hidden.style.display = "none";
          button.textContent = "Show more";
        }
      }
    });
  });
}
