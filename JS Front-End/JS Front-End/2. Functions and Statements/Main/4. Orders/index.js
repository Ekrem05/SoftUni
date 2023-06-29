const shop = {
  water: 1,
  coffee: 1.5,
  coke: 1.4,
  snacks: 2,
};

function order(productType, quantity) {
  let price = 0;
  price = shop[productType];
  console.log((price * quantity).toFixed(2));
}
order("water", 10);
