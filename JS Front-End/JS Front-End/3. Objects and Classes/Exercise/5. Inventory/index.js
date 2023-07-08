function solve(array) {
  let heros = [];
  array.forEach((element) => {
    const [heroName, level] = element.split(" / ");
    const itemsLeft = element.split(" / ")[2];
    const items = itemsLeft.split(", ");
    heros.push({
      heroName,
      level,
      items,
    });
  });
  for (const hero of heros.sort((a, b) => a.level - b.level)) {
    console.log(`Hero: ${hero.heroName}`);
    console.log(`level => ${hero.level}`);
    console.log(`items => ${hero.items.join(", ")}`);
  }
}
solve([
  "Isacc / 25 / Apple, GravityGun",
  "Derek / 12 / BarrelVest, DestructionSword",
  "Hes / 1 / Desolator, Sentinel, Antara",
]);
