const funcs = {
  multiply: (x, y) => x * y,
  divide: (x, y) => x / y,
  add: (x, y) => x + y,
  subtract: (x, y) => x - y,
};

function calcultor(x, y, action) {
  return funcs[action](x, y);
}
console.log(calcultor(100, 10, "divide"));
