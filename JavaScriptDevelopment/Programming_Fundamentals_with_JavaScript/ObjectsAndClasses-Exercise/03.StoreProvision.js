function storeProvision(store = [], delivery = []) {
    let result = [];
    class Store {
      constructor(productName, quantity) {
        this.productName = productName;
        this.quantity = quantity;
      }
    }
    
    for (let i = 0; i < store.length; i++) {
      if (i % 2 !== 0) {
        store[i] = +store[i];
      }
    }

    for (let i = 0; i < delivery.length; i += 2) {
      if (store.includes(delivery[i])) {
        let index = store.indexOf(delivery[i]);
        store[index + 1] += +delivery[i + 1];
      } else {
        store.push(delivery[i]);
        store.push(delivery[i + 1]);
      }
    }
  
    for (let i = 0; i < store.length; i += 2) {
      p = new Store(store[i], store[i + 1]);
      result.push(p);
    }
  
    for (const key of result) {
      console.log(`${key.productName} -> ${key.quantity}`);
    }
  }