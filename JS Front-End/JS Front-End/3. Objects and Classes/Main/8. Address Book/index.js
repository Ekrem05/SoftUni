function createMeeting(array) {
  let book = {};
  array.forEach((obj) => {
    const [name, address] = obj.split(":");
    book[name] = address;
  });

  const sortedKeys = Object.keys(book).sort((a, b) => {
    const nameA = a.toUpperCase();
    const nameB = b.toUpperCase();
    if (nameA < nameB) {
      return -1;
    }
    if (nameA > nameB) {
      return 1;
    }
    return 0;
  });

  sortedKeys.forEach((unit) => {
    console.log(`${unit} -> ${book[unit]}`);
  });
}
createMeeting([
  "Tim:Doe Crossing",
  "Bill:Nelson Place",
  "Peter:Carlyle Ave",
  "Bill:Ornery Rd",
]);
