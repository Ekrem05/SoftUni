function solve(sentence, x) {
  let count = 0;
  let text = sentence.split(" ");
  for (let word of text) {
    if (word === x) {
      count++;
    }
  }
  console.log(count);
}

solve("This is a word and it also is a sentence", "is");
