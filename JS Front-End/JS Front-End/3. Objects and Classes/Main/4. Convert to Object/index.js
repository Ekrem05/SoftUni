function convertToObj(json) {
  let obj = JSON.parse(json);
  let keys = Object.keys(obj);
  keys.forEach((key) => {
    console.log(`${key}: ${obj[key]}`);
  });
}
convertToObj('{"name": "George", "age": 40, "town": "Sofia"}');
