function solve(array) {
  const towns = array.map((item) => {
    let [town, latitude, longitude] = item.split(" | ");
    latitude = parseFloat(latitude);
    longitude = parseFloat(longitude);

    //take our values
    return {
      town,
      latitude,
      longitude,
    };
    //return properties with values
  });
  towns.forEach((town) => {
    const [name, lat, long] = Object.keys(town);
    console.log(
      `{ ${name}: '${town[name]}', ${lat}: '${town[lat].toFixed(
        2
      )}', ${long}: '${town[long].toFixed(2)}' }`
    );
  });
}
solve(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]);
