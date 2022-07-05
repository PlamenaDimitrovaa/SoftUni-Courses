window.addEventListener('load', async () => {
    const token = localStorage.getItem('token');
    if(token == null){
        window.location = '\\base\\login.html';
    }

    
    const form = document.querySelector('form');
    form.addEventListener('submit', onCreate);
});

async function onCreate(event){
    const url = 'http://localhost:3030/data/recipes';
    event.preventDefault();

    const form = event.target;
    const formData = new FormData(form);

    const name = formData.get('name').trim();
    const img = formData.get('img').trim();
    const ingredients = formData.get('ingredients').trim().split('\n');
    const steps = formData.get('steps').trim().split('\n');

    const recipe = {
        name, 
        img, 
        ingredients,
        steps,
    }

    const token = localStorage.getItem('token');
    if(token == null){
        window.location = '\\base\\login.html';
        return;
    }

    try {
        const res = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(recipe),
        })

        if(res.ok != true){
            const error = await res.json();
            throw new Error(error.message);
        }

        await res.json(); //За да видим дали ще върне грешка.
        window.location = '\\base\\index.html';
    } catch (err) {
        alert(err.message);
    }


}
