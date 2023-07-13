function deleteByEmail() {
  const input = document.querySelector("label>input").value;
  const arrayOfEmails = Array.from(
    document.querySelectorAll("table>tbody>tr>td:nth-child(2)")
  );
  const element = arrayOfEmails.filter((el) => el.textContent === input);
  const message = document.querySelector("#result");
  if (element) {
    element.parentElement.remove();

    message.textContent = "Deleted.";
  } else {
    message.textContent = "Not found.";
  }
}
