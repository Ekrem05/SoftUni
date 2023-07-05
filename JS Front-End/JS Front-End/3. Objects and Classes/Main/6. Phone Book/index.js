function createObject(array) {
  let book = [];
  array.forEach((obj) => {
    const [name, age] = obj.split(" ");
    book[name] = age;
  });
  for (const unit in book) {
    console.log(`${unit} -> ${book[unit]}`);
  }
}
createObject([
  "Tim 0834212554",
  "Peter 0877547887",
  "Bill 0896543112",
  "Tim 0876566344",
]);
