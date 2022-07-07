const baseUrl = 'http://localhost:3030/jsonstore/phonebook';

const phonebookUl = document.getElementById('phonebook');

const loadBtn = document.getElementById('btnLoad');

const personElement = document.getElementById('person');

const phoneElement = document.getElementById('phone');

const createBtn = document.getElementById('btnCreate');

function attachEvents() {
    loadBtn.addEventListener('click', getAllPhonebook);
    createBtn.addEventListener('click', createPost);
}

async function createPost(e){
    e.preventDefault();

    if(personElement.value !== '' && phoneElement.value !== ''){

        const data = {
            person: personElement.value,
            phone: phoneElement.value,
        }
    
        const res = await fetch(baseUrl, {
            method: 'post',
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify(data),
        })

        const result = await res.json();

        personElement.value = '';
        phoneElement.value = '';
        return result;
    }
}

async function getAllPhonebook(e){
    e.preventDefault();
    const res = await fetch(baseUrl);
    const data = await res.json();

    let elementsValues = Object.values(data);

    elementsValues.forEach(x => {
        const li = document.createElement('li');
        li.textContent = `${x.person}: ${x.phone}`;
        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete'; 
        deleteBtn.setAttribute('id', 'deleteBtn');
        li.appendChild(deleteBtn);
        phonebookUl.appendChild(li);

        deleteBtn.addEventListener('click', async function(e){

            const deleteUrl = `http://localhost:3030/jsonstore/phonebook/${x._id}>`; 
            e.preventDefault();
            
            let response = await fetch(deleteUrl, {
                method: 'delete',
            })
    
            const result = await response.json();
            li.remove();
            return result;
        });
    })
    
}


attachEvents();