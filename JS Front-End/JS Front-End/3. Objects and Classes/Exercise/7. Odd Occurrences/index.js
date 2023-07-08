function printOddOccurences(input) {
  let words = input.split(" ");
  const wordCount = {};
  words.forEach((word) => {
    lovercasedWord = word.toLowerCase();
    for (const currentWord of words) {
      if (currentWord.toLowerCase() == lovercasedWord) {
        if (wordCount.hasOwnProperty(lovercasedWord)) {
          wordCount[lovercasedWord] += 1;
        } else {
          wordCount[lovercasedWord] = 1;
        }
      }
    }
  });
  let selectedWords = [];
  arrayOfWords = Object.entries(wordCount);
  arrayOfWords
    .filter((word) => word[1] % 2 != 0)
    .forEach((word) => selectedWords.push(word[0]));
  console.log(selectedWords.join(" "));
}
printOddOccurences("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
