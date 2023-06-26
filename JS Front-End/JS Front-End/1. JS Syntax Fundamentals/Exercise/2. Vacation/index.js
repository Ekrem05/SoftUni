function vacation(count, groupType, dayOfWeek) {
  let costForOnePerson = 0;
  let disscount = 0;
  if (groupType === "Students") {
    switch (dayOfWeek) {
      case "Friday":
        costForOnePerson = 8.45;
        break;
      case "Saturday":
        costForOnePerson = 9.8;
        break;
      case "Sunday":
        costForOnePerson = 10.46;
        break;
    }
    if (count >= 30) disscount = count * costForOnePerson * 0.15;
  }
  if (groupType === "Business") {
    switch (dayOfWeek) {
      case "Friday":
        costForOnePerson = 10.9;
        break;

      case "Saturday":
        costForOnePerson = 15.6;
        break;

      case "Sunday":
        costForOnePerson = 16;
        break;
    }
    if (count >= 100) disscount = 10 * costForOnePerson;
  }
  if (groupType === "Regular") {
    switch (dayOfWeek) {
      case "Friday":
        costForOnePerson = 15;
        break;

      case "Saturday":
        costForOnePerson = 20;
        break;

      case "Sunday":
        costForOnePerson = 22.5;
        break;
    }
    if (count >= 10 && count <= 20) disscount = 0.05 * count * costForOnePerson;
  }
  let total = count * costForOnePerson - disscount;
  console.log(`Total price: ${total.toFixed(2)}`);
}
vacation(20, "Regular", "Saturday");
