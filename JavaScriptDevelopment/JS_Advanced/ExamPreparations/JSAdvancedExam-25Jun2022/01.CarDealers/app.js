window.addEventListener("load", solve);

function solve() {
 let makeElement = document.getElementById('make');
 let modelElement = document.getElementById('model');
 let yearElement = document.getElementById('year');
 let fuelElement = document.getElementById('fuel');

 let originalCostElement = document.getElementById('original-cost');
 let sellingPriceElement = document.getElementById('selling-price');

 let publishBtn = document.getElementById('publish');

 publishBtn.addEventListener('click', (e) => {
  e.preventDefault();

  let make = makeElement.value;
  let model = modelElement.value;
  let year = yearElement.value;
  let fuel = fuelElement.value;
  let originalCost = originalCostElement.value;
  let sellingPrice = sellingPriceElement.value;

  if(make == '' || model == '' || year == '' || fuel == '' || originalCost == '' || sellingPrice == '' || originalCost > sellingPrice){
    return;
  }

  let tbody = document.getElementById('table-body');

  let tr = document.createElement('tr');
  tr.classList.add('row');

  let makeTd = document.createElement('td');
  makeTd.textContent = `${make}`;

  let modelTd = document.createElement('td');
  modelTd.textContent = `${model}`;

  let yearTd = document.createElement('td');
  yearTd.textContent = `${year}`;

  let fuelTd = document.createElement('td');
  fuelTd.textContent = `${fuel}`;

  let priceTd = document.createElement('td');
  priceTd.textContent = `${originalCost}`;

  let newPriceTd = document.createElement('td');
  newPriceTd.textContent = `${sellingPrice}`;

  let buttonsTd = document.createElement('td');

  let editBtn = document.createElement('button');
  editBtn.classList.add('action-btn');
  editBtn.classList.add('edit');

  editBtn.textContent = 'Edit';

  let sellBtn = document.createElement('button');
  sellBtn.classList.add('action-btn');
  sellBtn.classList.add('sell');
  sellBtn.textContent = 'Sell';

  buttonsTd.appendChild(editBtn);
  buttonsTd.appendChild(sellBtn);

  tr.appendChild(makeTd);
  tr.appendChild(modelTd);
  tr.appendChild(yearTd);
  tr.appendChild(fuelTd);
  tr.appendChild(priceTd);
  tr.appendChild(newPriceTd);
  tr.appendChild(buttonsTd);

  tbody.appendChild(tr);

  makeElement.value = '';
  modelElement.value = '';
  yearElement.value = '';
  fuelElement.value = '';
  originalCostElement.value = '';
  sellingPriceElement.value = '';

  editBtn.addEventListener('click', (e) => {
    e.preventDefault();
    tbody.removeChild(tr);

    makeElement.value = make;
    modelElement.value = model;
    yearElement.value = year;
    fuelElement.value = fuel;
    originalCostElement.value = originalCost;
    sellingPriceElement.value = sellingPrice;
  })

  sellBtn.addEventListener('click', (e) => {
    e.preventDefault();
    tbody.removeChild(tr);

    let carsListUl = document.getElementById('cars-list');  
    let li = document.createElement('li');
    li.classList.add('each-list');
    let makeModelSpan = document.createElement('span');
    makeModelSpan.textContent = `${make} ${model}`;
    let yearSpan = document.createElement('span');
    yearSpan.textContent = `${year}`;
    let profitMadeSpan = document.createElement('span');
    profitMadeSpan.textContent = `${sellingPrice - originalCost}`;

    li.appendChild(makeModelSpan);
    li.appendChild(yearSpan);
    li.appendChild(profitMadeSpan);
    carsListUl.appendChild(li);

    let totalProfit = document.getElementById('profit');
    let initialPrice = Number(totalProfit.textContent);
    let priceToAdd = Number(profitMadeSpan.textContent);
    totalProfit.textContent = `${(priceToAdd + initialPrice).toFixed(2)}`;
  })
 })
}
