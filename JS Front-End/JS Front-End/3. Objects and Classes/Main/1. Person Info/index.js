function createObject(firstName, lastName, age) {
  return {
    firstName,
    lastName,
    age,
  };
}
const obj = createObject("Ekrem", "Beytula", 18);
console.log(JSON.stringify(obj));
