 const form = document.querySelector('form');

 export async function edit(e){
        e.preventDefault();
        const formData = new FormData(form);
        const title = formData.get('title').trim();
        const author = formData.get('author').trim();
        const bookId = form.dataset.bookId;

        try {
            const res = await fetch('http://localhost:3030/jsonstore/collections/books/' + bookId, {
                method: 'put',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({title, author})
            });

            if(res.ok != true){
                const err = await res.json();
                throw new Error(err.message);
            }

            form.reset();
            form.querySelector('h3').textContent = 'FORM';
            form.dataset.type='create';
            form.querySelector('button').textContent = 'Save';

        } catch (error) {
            alert(error.message);
        }
    }

    export async function onEdit(target){
        const bookId = target.parentElement.dataset.id;
        const res = await fetch('http://localhost:3030/jsonstore/collections/books/' + bookId);
        const book = await res.json();

        form.querySelector('[name="title"]').value = book.title;
        form.querySelector('[name="author"]').value = book.author;
        form.dataset.bookId = bookId;

        form.querySelector('h3').textContent = 'Edit FORM';
        form.dataset.type= 'edit';
    }