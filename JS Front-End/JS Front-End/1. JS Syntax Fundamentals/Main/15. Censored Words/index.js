function solve(sentence, word) {
  const censored = "*".repeat(word.length);
  while (sentence.includes(word)) {
    sentence = sentence.replace(word, censored);
  }
  console.log(sentence);
}

solve("Find the hidden word hidden", "hidden");
