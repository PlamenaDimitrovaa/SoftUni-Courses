window.addEventListener('load', solve);

function solve() {
    let modelElement = document.getElementById('model');
    let yearElement = document.getElementById('year');
    let descriptionElement = document.getElementById('description');
    let priceElement = document.getElementById('price');
    let addButton = document.getElementById('add');
    let furnitureList = document.getElementById('furniture-list');

    addButton.addEventListener('click', addFurniture);
    let totalPrice = document.querySelector('.total-price');

    function addFurniture(e){
        e.preventDefault();
        let yearValue = Number(yearElement.value);
        let priceValue = Number(priceElement.value);
        if(modelElement.value != '' && descriptionElement.value != '' && yearValue > 0 && priceValue > 0){
            let tr = document.createElement('tr');
            tr.classList.add('info');
            tr.innerHTML = `<td>${modelElement.value}</td>
                            <td>${priceValue.toFixed(2)}</td>
                            <td><button class = "moreBtn">More Info</button>
                            <button class = "buyBtn">Buy it</button>
                            </td>`;
            let hideTr = document.createElement('tr');
            hideTr.classList.add('hide');
            hideTr.innerHTML = `<td>Year: ${yearValue}</td><td colspan = "3">Description: ${descriptionElement.value}</td>`;
            furnitureList.appendChild(tr);
            furnitureList.appendChild(hideTr);

            let moreInfoButtons = tr.querySelectorAll('button');
            moreInfoButtons[0].addEventListener('click', showMoreInfo);
            moreInfoButtons[1].addEventListener('click', buyFurniture);
        }

        modelElement.value = '';
        yearElement.value = '';
        descriptionElement.value = '';
        priceElement.value = '';
    }

    function showMoreInfo(e){
        let moreInfoTr = e.target.parentElement.parentElement.nextElementSibling;
        if(e.target.textContent = "More Info"){
            e.target.textContent = "Less Info";
            moreInfoTr.style.display = "contents";
        } else{
            e.target.textContent = "More Info";
            moreInfoTr.style.display = "none";
        }
    }

    function buyFurniture(e){
        let tr = e.target.parentElement.parentElement;
        let hideTr = tr.nextElementSibling;
        hideTr.parentElement.removeChild(hideTr);
        let price = Number(tr.querySelectorAll("td")[1].textContent);
        totalPrice.textContent = (Number(totalPrice.textContent) + price).toFixed(2);
        tr.parentElement.removeChild(tr);
    }
}
