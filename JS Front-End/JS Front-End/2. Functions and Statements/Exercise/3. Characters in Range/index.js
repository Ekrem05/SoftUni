function charsInRange(first, second) {
  let firstChar = first.charCodeAt(0);
  let secondChar = second.charCodeAt(0);
  function printChars(firstChar, secondChar) {
    let array = [];
    for (i = firstChar + 1; i < secondChar; i++) {
      array.push(String.fromCharCode(i));
    }
    return array;
  }
  let result = [];
  if (firstChar > secondChar) result = printChars(secondChar, firstChar);
  else result = printChars(firstChar, secondChar);
  return result.join(" ");
}

console.log(charsInRange("#", ":"));
