function addItem(){
    let listOfElements = document.getElementById('items');
    let inputElement = document.getElementById('newItemText');
    let liElement = document.createElement('li');
    liElement.textContent = inputElement.value;
    listOfElements.appendChild(liElement);
}