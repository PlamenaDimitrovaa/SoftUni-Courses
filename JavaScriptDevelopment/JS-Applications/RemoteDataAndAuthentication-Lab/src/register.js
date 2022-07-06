document.querySelector('form').addEventListener('submit', onSubmit);

async function onSubmit(event){
    event.preventDefault();
    const url = 'http://localhost:3030/users/register';

    const formData = new FormData(event.target);

        const email = formData.get('email');
        const password = formData.get('password');
        const repass = formData.get('rePass');

    try {
        if(password == '' || email == ''){
            throw new Error('All fields are required!'); 
        }

        if(password !== repass){
            throw new Error('Passwords don\'t match!'); 
        }

        const response = await fetch(url, {
            method: 'post', 
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({email, password}),
        })

        if(response.ok !== true){
            const err = await response.json();
            throw new Error(err.message);
        }

        const data = await response.json();
        const token = data.accessToken;

        sessionStorage.setItem('accessToken', token);

        window.location = '\\base\\index.html';

    } catch (error) {
        alert(error.message);
    }
}