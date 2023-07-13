const obj = {
  prop1: "value1",
  prop2: "value2",
};

delete obj.prop1;

console.log(obj); // Output: { prop2: 'value2' }
