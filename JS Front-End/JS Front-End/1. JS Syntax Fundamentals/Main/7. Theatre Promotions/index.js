function solve(day, age) {
  switch (day) {
    case "Weekday":
      if (0 <= age && age <= 18) {
        console.log("12$");
      } else if (18 < age && age <= 64) {
        console.log("18$");
      } else if (64 < age && age <= 122) {
        console.log("12$");
      } else {
        console.log("Error!");
      }
      break;
    case "Weekend":
      if (0 <= age && age <= 18) {
        console.log("15$");
      } else if (18 < age && age <= 64) {
        console.log("20$");
      } else if (64 < age && age <= 122) {
        console.log("15$");
      } else {
        console.log("Error!");
      }
      break;
    case "Holiday":
      if (0 <= age && age <= 18) {
        console.log("5$");
      } else if (18 < age && age <= 64) {
        console.log("12$");
      } else if (64 < age && age <= 122) {
        console.log("10$");
      } else {
        console.log("Error!");
      }
      break;
    default:
      console.log("Error!");
  }
}

solve("Holiday", 15);
