function grades(grade) {
  if (grade >= 5.5) console.log(`Excellent (${grade.toFixed(2)})`);
  else if (grade >= 4.5) console.log(`Very good (${grade.toFixed(2)})`);
  else if (grade >= 3.5) console.log(`Good (${grade.toFixed(2)})`);
  else if (grade >= 3) console.log(`Poor (${grade.toFixed(2)})`);
  else if (grade < 3) {
    console.log("Fail (2)");
  }
}
grades(4.5);
