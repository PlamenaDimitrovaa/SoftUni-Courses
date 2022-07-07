async function solve(){
    
    const url = 'http://localhost:3030/jsonstore/collections/students';
    const table = document.querySelector('#results tbody');

    const response = await fetch(url);
    const data = await response.json();

    Object.values(data).forEach(s => {
        const firstName = s.firstName;
        const lastName = s.lastName;
        const facultyNumber = s.facultyNumber;
        const grade = Number(s.grade);

            const tr = document.createElement('tr');
            const fNameTd = document.createElement('td');
            fNameTd.textContent = firstName;
            const lNameTd = document.createElement('td');
            lNameTd.textContent = lastName;
            const facultyNumberTd = document.createElement('td');
            facultyNumberTd.textContent = facultyNumber;
            const gradeTd = document.createElement('td');
            gradeTd.textContent = grade;
    
            tr.appendChild(fNameTd);
            tr.appendChild(lNameTd);
            tr.appendChild(facultyNumberTd);
            tr.appendChild(gradeTd);
    
            table.appendChild(tr);
    })

    const submitBtn = document.getElementById('submit');
    const form = document.querySelector('form');
    
    submitBtn.addEventListener('click', onSubmit);
    
    async function onSubmit(e){
        e.preventDefault();
    
            const formData = new FormData(form);
            const firstNameElement = formData.get('firstName');
            const lastNameElement = formData.get('lastName');
            const facultyNumberElement = formData.get('facultyNumber');
            const gradeElement = formData.get('grade');
           
            if(isNaN(facultyNumberElement) || isNaN(gradeElement) || firstNameElement == ''
                || lastNameElement == '' || facultyNumberElement == '' || gradeElement == ''){
                alert('Wrong input');
                return;
            }
    
        const res = await fetch(url, {
            method:  'post',
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify(
                {
                    firstName: firstNameElement,
                    lastName: lastNameElement, 
                    facultyNumber: facultyNumberElement, 
                    grade: gradeElement,
                })
            });

            const tr = document.createElement('tr');
            const fNameTd = document.createElement('td');
            fNameTd.textContent = firstNameElement;
            const lNameTd = document.createElement('td');
            lNameTd.textContent = lastNameElement;
            const facultyNumberTd = document.createElement('td');
            facultyNumberTd.textContent = facultyNumberElement;
            const gradeTd = document.createElement('td');
            gradeTd.textContent = gradeElement;
    
            tr.appendChild(fNameTd);
            tr.appendChild(lNameTd);
            tr.appendChild(facultyNumberTd);
            tr.appendChild(gradeTd);
    
            table.appendChild(tr);

           form.reset();
    }
}

solve();
