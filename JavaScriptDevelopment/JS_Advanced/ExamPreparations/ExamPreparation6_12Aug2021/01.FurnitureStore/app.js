window.addEventListener('load', solve);

function solve(){
    let modelElement = document.getElementById('model');
    let yearElement = document.getElementById('year');
    let descriptionElement = document.getElementById('description');
    let priceElement = document.getElementById('price');

    let addBtn = document.getElementById('add');
    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        if(modelElement.value == '' || descriptionElement.value == '' 
            || yearElement.value <= 0 || priceElement.value <= 0){
            return;
        }

        let model = modelElement.value;
        let year = Number(yearElement.value);
        let description = descriptionElement.value;
        let price = Number(priceElement.value);

        let body = document.getElementById('furniture-list');
        let infoTr = document.createElement('tr');
        infoTr.className = 'info';
        let modelTd = document.createElement('td');
        modelTd.textContent = `${model}`;
        let priceTd = document.createElement('td');
        priceTd.textContent = `${price.toFixed(2)}`;

        let btnTd = document.createElement('td');
        let moreInfoBtn = document.createElement('button');
        moreInfoBtn.classList.add('moreBtn');
        moreInfoBtn.textContent = 'More Info';
        let buyItBtn = document.createElement('button');
        buyItBtn.classList.add('buyBtn');
        buyItBtn.textContent = 'Buy it';
        
        btnTd.appendChild(moreInfoBtn);
        btnTd.appendChild(buyItBtn);
        infoTr.appendChild(modelTd);
        infoTr.appendChild(priceTd);
        infoTr.appendChild(btnTd);

        let hideTr = document.createElement('tr');
        hideTr.className = 'hide';
        let yearTd = document.createElement('td');
        yearTd.textContent = `Year: ${year}`;
        let descriptionTd = document.createElement('td');
        descriptionTd.setAttribute('colspan', '3');
        descriptionTd.textContent = `Description: ${description}`;

        hideTr.appendChild(yearTd);
        hideTr.appendChild(descriptionTd);

        body.appendChild(infoTr);
        body.appendChild(hideTr);

        modelElement.value = '';
        yearElement.value = '';
        descriptionElement.value = '';
        priceElement.value = '';

        moreInfoBtn.addEventListener('click', (e) => {
            e.preventDefault();
            if(moreInfoBtn.textContent == 'More Info'){
                moreInfoBtn.textContent = 'Less Info';
                hideTr.style.display = 'contents';
            } else{
                moreInfoBtn.textContent = 'More Info';
                hideTr.style.display = 'none';
            }
        })

        buyItBtn.addEventListener('click', (e) => {
            e.preventDefault();
            infoTr.remove();
            hideTr.remove();

            let totalPrice = document.querySelector('.total-price');
            let initialPrice = Number(totalPrice.textContent);
            totalPrice.textContent = (Number(price) + initialPrice).toFixed(2);
        })
    })
}

// function solve() {
//     let modelElement = document.getElementById('model');
//     let yearElement = document.getElementById('year');
//     let descriptionElement = document.getElementById('description');
//     let priceElement = document.getElementById('price');
//     let addButton = document.getElementById('add');
//     let furnitureList = document.getElementById('furniture-list');

//     addButton.addEventListener('click', addFurniture);
//     let totalPrice = document.querySelector('.total-price');

//     function addFurniture(e){
//         e.preventDefault();
//         let yearValue = Number(yearElement.value);
//         let priceValue = Number(priceElement.value);
//         if(modelElement.value != '' && descriptionElement.value != '' && yearValue > 0 && priceValue > 0){
//             let tr = document.createElement('tr');
//             tr.classList.add('info');
//             tr.innerHTML = `<td>${modelElement.value}</td>
//                             <td>${priceValue.toFixed(2)}</td>
//                             <td><button class = "moreBtn">More Info</button>
//                             <button class = "buyBtn">Buy it</button>
//                             </td>`;
//             let hideTr = document.createElement('tr');
//             hideTr.classList.add('hide');
//             hideTr.innerHTML = `<td>Year: ${yearValue}</td><td colspan = "3">Description: ${descriptionElement.value}</td>`;
//             furnitureList.appendChild(tr);
//             furnitureList.appendChild(hideTr);

//             let moreInfoButtons = tr.querySelectorAll('button');
//             moreInfoButtons[0].addEventListener('click', showMoreInfo);
//             moreInfoButtons[1].addEventListener('click', buyFurniture);
//         }

//         modelElement.value = '';
//         yearElement.value = '';
//         descriptionElement.value = '';
//         priceElement.value = '';
//     }

//     function showMoreInfo(e){
//         let moreInfoTr = e.target.parentElement.parentElement.nextElementSibling;
//         if(e.target.textContent = "More Info"){
//             e.target.textContent = "Less Info";
//             moreInfoTr.style.display = "contents";
//         } else{
//             e.target.textContent = "More Info";
//             moreInfoTr.style.display = "none";
//         }
//     }

//     function buyFurniture(e){
//         let tr = e.target.parentElement.parentElement;
//         let hideTr = tr.nextElementSibling;
//         hideTr.parentElement.removeChild(hideTr);
//         let price = Number(tr.querySelectorAll("td")[1].textContent);
//         totalPrice.textContent = (Number(totalPrice.textContent) + price).toFixed(2);
//         tr.parentElement.removeChild(tr);
//     }
// }
