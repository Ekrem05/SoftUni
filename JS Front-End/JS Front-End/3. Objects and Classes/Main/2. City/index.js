function printKeys(object) {
  let keys = Object.keys(object);
  keys.forEach((key) => {
    console.log(`${key} -> ${object[key]}`);
  });
}
printKeys({
  name: "Sofia",
  area: 492,
  population: 1238438,
  country: "Bulgaria",
  postCode: "1000",
});
