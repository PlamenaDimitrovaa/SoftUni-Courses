function solve(){
    const loadAllBooksBtn = document.getElementById('loadBooks');
    const url = 'http://localhost:3030/jsonstore/collections/books';
    const table = document.querySelector('body table tbody');
    const form = document.querySelector('form');

    const submitBtn = document.querySelector('form button');
    submitBtn.addEventListener('click', onSubmit);

    async function onSubmit(e){
        e.preventDefault();
        const formData = new FormData(form);
        const title = formData.get('title');
        const author = formData.get('author');

        if(title == '' || author == ''){
            alert('All fields are required!');
            return;
        }

        const res = fetch(url, {
            method: 'post',
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify({
                title,
                author
            })
        })
            const tr = document.createElement('tr');
            const titleTd = document.createElement('td');
            titleTd.textContent = title;
            const authorTd = document.createElement('td');
            authorTd.textContent = author;
            const buttonTd = document.createElement('td');
            const editBtn = document.createElement('button');
            editBtn.textContent = 'Edit';
            //addEventListener('click', edit);

            const deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', remove);

            buttonTd.appendChild(editBtn);
            buttonTd.appendChild(deleteBtn);

            tr.appendChild(titleTd);
            tr.appendChild(authorTd);
            tr.appendChild(buttonTd);

            table.appendChild(tr);

            form.reset();

            function remove(e){
                e.preventDefault();
                fetch(`${url}/${formData.get('_id')}`, {
                    method: "DELETE"
                })

                tr.remove();
            }
    }

    loadAllBooksBtn.addEventListener('click', loadAllBooks);

    async function loadAllBooks(e){
        e.preventDefault();
        const response = await fetch(url);
        if(response.status !== 200){
            throw new Error('Problem loading data!');
        }

        const data = await response.json();
        table.innerHTML = '';

        Object.values(data).forEach(b => {
            const tr = document.createElement('tr');
            const titleTd = document.createElement('td');
            titleTd.textContent = b.title;
            const authorTd = document.createElement('td');
            authorTd.textContent = b.author;
            const buttonTd = document.createElement('td');
            const editBtn = document.createElement('button');
            editBtn.textContent = 'Edit';
           // editBtn.addEventListener('click', edit);
            const deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', remove);
            buttonTd.appendChild(editBtn);
            buttonTd.appendChild(deleteBtn);

            tr.appendChild(titleTd);
            tr.appendChild(authorTd);
            tr.appendChild(buttonTd);

            table.appendChild(tr);

            function remove(e){
                e.preventDefault();
                fetch(`${url}/${b._id}`, {
                    method: "DELETE"
                })

                tr.remove();
            }
        })
    };
}

solve();

