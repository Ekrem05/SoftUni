function solve() {
  const btnAdd = document.querySelector("#add-product");
  const btnLoad = document.querySelector("#load-product");
  const btnUpdate = document.querySelector("#update-product");
  let itemToEditId;
  const input = {
    name: document.querySelector("#product"),
    count: document.querySelector("#count"),
    price: document.querySelector("#price"),
  };
  const productsList = document.querySelector("#tbody");
  btnLoad.addEventListener("click", loadList);
  btnAdd.addEventListener("click", addProduct);
  btnUpdate.addEventListener("click", confirmUpdate);

  async function loadList(e) {
    e.preventDefault();
    productsList.innerHTML = "";
    const req = await fetch("http://localhost:3030/jsonstore/grocery/");
    const data = await req.json();
    Object.values(data).forEach((product) => {
      const table = createItem("tr");
      const name = createItem("td", null, ["name"], product.product, table);
      const count = createItem(
        "td",
        null,
        ["count-product"],
        product.count,
        table
      );
      const price = createItem(
        "td",
        null,
        ["product-price"],
        product.price,
        table
      );
      const buttons = createItem("td", null, ["btn"], null);
      const updatebtn = createItem(
        "button",
        null,
        ["update", product._id],
        "Update",
        buttons
      );
      updatebtn.addEventListener("click", updateProduct);
      const deletebtn = createItem(
        "button",
        null,
        ["delete", product._id],
        "Delete",
        buttons
      );
      deletebtn.addEventListener("click", deleteProduct);

      table.appendChild(buttons);
      productsList.appendChild(table);
    });
  }
  function createItem(tag, id, classes, textContent, parent) {
    const item = document.createElement(tag);
    if (textContent) {
      item.textContent = textContent;
    }
    if (classes) {
      item.classList = [...classes].join(" ");
    }
    if (id) {
      item.id = id;
    }

    if (parent) {
      parent.appendChild(item);
    }
    return item;
  }
  async function addProduct(e) {
    e.preventDefault();
    const product = {
      product: input.name.value,
      count: input.count.value,
      price: input.price.value,
    };
    await fetch("http://localhost:3030/jsonstore/grocery/", {
      method: "POST",
      body: JSON.stringify(product),
    });
    Object.values(input).forEach((input) => (input.value = ""));
    loadList(e);
  }
  async function deleteProduct(e) {
    const productId = e.currentTarget.classList[1];
    await fetch(`http://localhost:3030/jsonstore/grocery/${productId}`, {
      method: "DELETE",
      body: null,
    });
    loadList(e);
  }
  function updateProduct(e) {
    const product = e.currentTarget.parentElement.parentElement;
    input.name.value = product.children[0].textContent;
    input.count.value = product.children[1].textContent;
    input.price.value = product.children[2].textContent;
    btnUpdate.disabled = false;
    itemToEditId = e.currentTarget.classList[1];
  }
  async function confirmUpdate(e) {
    e.preventDefault();

    const product = {
      product: input.name.value,
      count: input.count.value,
      price: input.price.value,
    };
    await fetch(`http://localhost:3030/jsonstore/grocery/${itemToEditId}`, {
      method: "PATCH",
      body: JSON.stringify(product),
    });
    Object.values(input).forEach((input) => (input.value = ""));
    btnUpdate.disabled = true;

    loadList(e);
  }
}
solve();
