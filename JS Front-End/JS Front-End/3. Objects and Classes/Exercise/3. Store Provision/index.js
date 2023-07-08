function solve(array1, array2) {
  const shop = {};
  for (i = 0; i < array1.length; i++) {
    let count = parseInt(array1[i + 1]);
    if (i % 2 == 0) {
      shop[array1[i]] = count;
    }
  }
  for (i = 0; i < array2.length; i++) {
    let count = parseInt(array2[i + 1]);
    if (i % 2 == 0) {
      if (shop.hasOwnProperty(array2[i])) shop[array2[i]] += count;
      else {
        shop[array2[i]] = count;
      }
    }
  }
  Object.keys(shop).forEach((key) => {
    console.log(`${key} -> ${shop[key]}`);
  });
}
solve(
  ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
  ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
);
