function fruit(fruitType, weight, pricePerKg) {
  console.log(
    `I need $${((weight * pricePerKg) / 1000).toFixed(2)} to buy ${(
      weight / 1000
    ).toFixed(2)} kilograms ${fruitType}.`
  );
}
fruit("apple", 1563, 2.35);
