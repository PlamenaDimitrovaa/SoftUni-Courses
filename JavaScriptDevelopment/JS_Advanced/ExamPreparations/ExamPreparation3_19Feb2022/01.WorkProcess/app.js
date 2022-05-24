// function solve() {
//     let firstNameElement = document.getElementById('fname');
//     let lastNameElement = document.getElementById('lname');
//     let emailElement = document.getElementById('email');
//     let dateOfBirthElement = document.getElementById('birth');
//     let positionElement = document.getElementById('position');
//     let salaryElement = document.getElementById('salary');
//     let hireWorkerButton = document.getElementById('add-worker');
//     let bodyElement = document.getElementById('tbody');
//     let divElement = document.querySelector('.tbl-content');
    
//     // if(firstNameElement.value == "" || lastNameElement.value == "" || emailElement.value == "" || dateOfBirthElement.value == "" || 
//     // positionElement.value == "" || salaryElement.value == ""){
//     //     return;        
//     // }
    
//     hireWorkerButton.addEventListener('click', (e) => {
        
//         e.preventDefault();
        
//         let trElement = document.createElement('tr');
//         let tdFNameEl = document.createElement('td');
//         let tdLNameEl = document.createElement('td');
//         let emailEl = document.createElement('td');
//         let birthEl = document.createElement('td');
//         let positionEl = document.createElement('td');
//         let salaryEl = document.createElement('td');
//         let firedButton = document.createAttribute('button');
//         let editButton = document.createAttribute('button');

//         tdFNameEl.textContent = firstNameElement.value;
//         tdLNameEl.textContent = lastNameElement.value;
//         emailEl.textContent = emailElement.value;
//         birthEl.textContent = dateOfBirthElement.value;
//         positionEl.textContent = positionElement.value;
//         salaryEl.textContent = salaryElement.value;
//         // firedButton.setAttribute("class", "fired");
//         // editButton.setAttribute("class", "edit");
//         firedButton.textContent = 'Fired';
//         editButton.textContent = 'Edit';

//         trElement.appendChild(tdFNameEl);
//         trElement.appendChild(tdLNameEl);
//         trElement.appendChild(emailEl);
//         trElement.appendChild(birthEl);
//         trElement.appendChild(positionEl);
//         trElement.appendChild(salaryEl);
//         trElement.appendChild(firedButton);
//         trElement.appendChild(editButton);

//         bodyElement.appendChild(trElement);
//         divElement.appendChild(bodyElement);
//     })
// }
// solve()