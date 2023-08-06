function solve(array) {
  const n = Number(array[0]);
  const input = array.splice(1, n);
  const commands = array.slice(1);

  const riders = input.reduce((obj, current) => {
    const [rider, fuelCapacity, position] = current.split("|");
    obj[rider] = {
      fuelCapacity,
      position,
    };
    return obj;
  }, {});
  commands.forEach((command) => {
    const line = command.split(" - ");
    const action = line[0];
    if (action == "StopForFuel") {
      const rider = line[1];
      const minFuel = line[2];
      const changePos = line[3];
      if (riders[rider].fuelCapacity < Number(minFuel)) {
        riders[rider].position = changePos;
        console.log(
          `${rider} stopped to refuel but lost his position, now he is ${changePos}.`
        );
      } else {
        console.log(`${rider} does not need to stop for fuel!`);
      }
    } else if (action == "Overtaking") {
      const rider1 = line[1];
      const rider2 = line[2];
      if (riders[rider1].position < riders[rider2].position) {
        const rider1pos = riders[rider1].position;
        const rider2pos = riders[rider2].position;
        riders[rider1].position = rider2pos;
        riders[rider2].position = rider1pos;
        console.log(`${rider1} overtook ${rider2}!`);
      }
    } else if (action == "EngineFail") {
      const rider = line[1];
      const laps = line[2];
      delete riders[rider];
      console.log(
        `${rider} is out of the race because of a technical issue, ${laps} laps before the finish.`
      );
    }
  });
  Object.keys(riders).forEach((rider) => {
    console.log(rider);
    console.log(`   Final position: ${riders[rider].position}`);
  });
}
solve([
  "4",
  "Valentino Rossi|100|1",
  "Marc Marquez|90|3",
  "Jorge Lorenzo|80|4",
  "Johann Zarco|80|2",
  "StopForFuel - Johann Zarco - 90 - 5",
  "Overtaking - Marc Marquez - Jorge Lorenzo",
  "EngineFail - Marc Marquez - 10",
  "Finish",
]);
