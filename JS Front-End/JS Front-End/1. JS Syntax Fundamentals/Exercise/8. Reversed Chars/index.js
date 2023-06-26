function charsToString(...chars) {
  let string = chars.join(" ");
  let array = string.split(" ").reverse();
  console.log(array.join(" "));
}
charsToString("A", "B", "C");
