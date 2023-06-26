function roadRadar(speed, area) {
  let speedLimit = 0;
  switch (area) {
    case "motorway":
      speedLimit = 130;
      break;
    case "interstate":
      speedLimit = 90;
      break;
    case "city":
      speedLimit = 50;
      break;
    case "residential":
      speedLimit = 20;
      break;
  }
  let status = "";
  const speedDiff = speed - speedLimit;
  if (speedDiff > 0) {
    if (speedDiff <= 20) {
      status = "speeding";
    } else if (speedDiff <= 40) {
      status = "excessive speeding";
    } else {
      status = "reckless driving";
    }
    console.log(
      `The speed is ${
        speed - speedLimit
      } km/h faster than the allowed speed of ${speedLimit} - ${status}`
    );
  } else {
    console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
  }
}
roadRadar(220, "interstate");
