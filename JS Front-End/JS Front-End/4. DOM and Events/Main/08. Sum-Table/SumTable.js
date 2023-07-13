function sumTable() {
  const rows = Array.from(document.querySelectorAll("td:nth-child(2)"));
  const sum = rows.reduce((acc, current) => {
    acc += Number(current.textContent);
    return acc;
  }, 0);
  const result = document.querySelector("#sum");
  result.textContent = sum;
}
