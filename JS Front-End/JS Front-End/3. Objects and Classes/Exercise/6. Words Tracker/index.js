function findMatches(array) {
  let wordsLookingFor = array[0].split(" ");
  array[0] = "";
  const wordCount = wordsLookingFor.reduce((obj, current) => {
    obj[current] = 0;
    return obj;
  }, {});
  array.forEach((word) => {
    if (wordCount.hasOwnProperty(word)) {
      wordCount[word] += 1;
    }
  });
  const kvp = Object.entries(wordCount);

  for (const word of kvp.sort((a, b) => b[1] - a[1])) {
    console.log(`${word[0]} - ${word[1]}`);
  }
}
findMatches([
  "is the",
  "first",
  "sentence",
  "Here",
  "is",
  "another",
  "the",
  "And",
  "finally",
  "the",
  "the",
  "sentence",
]);
