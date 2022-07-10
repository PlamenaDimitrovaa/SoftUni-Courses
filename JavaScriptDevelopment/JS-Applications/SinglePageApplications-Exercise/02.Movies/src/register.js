import { homePage } from "./home.js";
import { showView, updateNav } from "./util.js";

const section = document.querySelector('#form-sign-up');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function registerPage(){
    showView(section);
}

async function onSubmit(event){
    event.preventDefault();

    const formData = new FormData(form);

    const email = formData.get('email');
    const password = formData.get('password');
    const repeatPassword = formData.get('repeatPassword');

    await register(email, password, repeatPassword);
    form.reset();
    updateNav();
    homePage();
}

async function register(email, password, repeatPassword){
    try {
        const res = await fetch('http://localhost:3030/users/register', {
            method: 'post', 
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify({email, password, repeatPassword})
        });

        if(password !== repeatPassword){
            alert('Passwords must match!');
            throw new Error('Passwords must match!');
        }
        if(!res.ok){
            const err = await res.json();
            throw new Error(err.message);
        }

        const user = await res.json();
        localStorage.setItem('user', JSON.stringify(user));
    } catch (error) {
        alert(error.message);
        throw error;
    }
}
