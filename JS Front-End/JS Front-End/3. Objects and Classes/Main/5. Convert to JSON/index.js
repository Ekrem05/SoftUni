function createObject(name, lastName, hairColor) {
  const obj = {
    name,
    lastName,
    hairColor,
  };
  console.log(JSON.stringify(obj));
}
createObject("George", "Jones", "Brown");
