function createMeeting(array) {
  let book = [];
  array.forEach((obj) => {
    const [dayOfWeek, name] = obj.split(" ");
    if (!book[dayOfWeek]) {
      book[dayOfWeek] = name;
      console.log(`Scheduled for ${dayOfWeek}`);
    } else {
      console.log(`Conflict on ${dayOfWeek}!`);
    }
  });
  for (const unit in book) {
    console.log(`${unit} -> ${book[unit]}`);
  }
}
createMeeting(["Monday Peter", "Wednesday Bill", "Monday Tim", "Friday Tim"]);
