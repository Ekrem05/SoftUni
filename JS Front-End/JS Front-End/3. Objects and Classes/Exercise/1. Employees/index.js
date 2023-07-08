function solve(array) {
  const employees = array.reduce((obj, current) => {
    obj[current] = current.length;
    return obj;
  }, {});
  Object.keys(employees).forEach((prop) => {
    console.log(`Name: ${prop} -- Personal Number: ${employees[prop]}`);
  });
}
solve([
  "Silas Butler",
  "Adnaan Buckley",
  "Juan Peterson",
  "Brendan Villarreal",
]);
