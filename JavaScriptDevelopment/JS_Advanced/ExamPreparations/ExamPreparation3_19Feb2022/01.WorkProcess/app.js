function solve() {
    let fNameElement = document.getElementById('fname');
    let lNameElement = document.getElementById('lname');
    let emailElement = document.getElementById('email');
    let birthElement = document.getElementById('birth');
    let positionElement = document.getElementById('position');
    let salaryElement = document.getElementById('salary');
    let addWorkerButton = document.getElementById('add-worker');

    const inputValues = Array.from(document.querySelector('#signup > form').querySelectorAll('input'));
    
    addWorkerButton.addEventListener('click', (e) => {
        e.preventDefault();
        if(fNameElement.value && lNameElement.value && emailElement.value && birthElement.value && positionElement.value && salaryElement.value){

            let tableBody = document.getElementById('tbody');
    
            let tr = document.createElement('tr');
    
            let fNameTd = document.createElement('td');
            fNameTd.textContent = fNameElement.value;
            let lNameTd = document.createElement('td');
            lNameTd.textContent = lNameElement.value;
            let emailTd = document.createElement('td');
            emailTd.textContent = emailElement.value;
            let birthTd = document.createElement('td');
            birthTd.textContent = birthElement.value;
            let positionTd = document.createElement('td');
            positionTd.textContent = positionElement.value;
            let salaryTd = document.createElement('td');
            salaryTd.textContent = salaryElement.value;
    
            let buttonTd = document.createElement('td');
    
            let firedButton = document.createElement('button');
            firedButton.className = 'fired';
            firedButton.textContent = "Fired";
    
            let editButton = document.createElement('button');
            editButton.className = 'edit';
            editButton.textContent = "Edit";
    
            let sum = document.getElementById('sum');

            firedButton.addEventListener('click', (e) => {
                e.target.parentElement.parentElement.remove();
                let tdCollection = Array.from(e.target.parentElement.parentElement.querySelectorAll('td'));
                sum.textContent = (Number(sum.textContent) - Number(tdCollection[5].textContent)).toFixed(2);
            })

            editButton.addEventListener('click', () => {
                const tdItems = Array.from(tr.childNodes);
                
                for (let i = 0; i < tdItems.length - 1; i++) {
                    inputValues[i].value = tdItems[i].textContent;
                }
                
                tr.remove();
                
                sum.textContent = (Number(sum.textContent) - Number(inputValues[5].value)).toFixed(2);
            })
            
            buttonTd.appendChild(firedButton);
            buttonTd.appendChild(editButton);
    
            tr.appendChild(fNameTd);
            tr.appendChild(lNameTd);
            tr.appendChild(emailTd);
            tr.appendChild(birthTd);
            tr.appendChild(positionTd);
            tr.appendChild(salaryTd);
            tr.appendChild(buttonTd);
    
            tableBody.appendChild(tr);
            sum.textContent = (Number(sum.textContent) + Number(salaryElement.value)).toFixed(2);

            fNameElement.value = '';
            lNameElement.value = '';
            emailElement.value = '';
            birthElement.value = '';
            positionElement.value = '';
            salaryElement.value = '';
        }
    })
}
solve()