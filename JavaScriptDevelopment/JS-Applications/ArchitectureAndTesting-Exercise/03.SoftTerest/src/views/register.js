import { register } from "../api/users.js";

const section = document.getElementById('registerPage');

const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

let ctx = null;

export function showRegister(context){
    ctx = context;
    context.showSection(section);
}

async function onSubmit(e){
    e.preventDefault();
    const formData = new FormData(form);
    const email = formData.get('email');
    const password = formData.get('password');
    const repeatPassword = formData.get('repeatPassword');

    if(password !== repeatPassword){
        alert('Passwords must match!');
        throw new Error('Passwords must match!');
    }

    await register(email, password);
    form.reset();
    ctx.updateNav();
    ctx.goTo('/');
}
