import { showView } from "./util.js";
import { homePage } from "./home.js";

const section = document.querySelector('#add-movie');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function createPage(){
    showView(section);
}

async function onSubmit(event){
    event.preventDefault();

    const formData = new FormData(form);

    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageUrl');

    await createMovie(title, description, img);
    form.reset();
    homePage();
}

async function createMovie(title, description, img){
    try {
        const user = JSON.parse(localStorage.getItem('user'));

        
        const res = await fetch('http://localhost:3030/data/movies', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': user.accessToken
            },
            body: JSON.stringify({title, description, img}),
        })

        if(!user){
            const err = await res.json();
            throw new Error(err.message);
        }
        
        if(title == '' || description == '' || img == ''){
            throw new Error('All fields are required!');
        }

        if(!res.ok){
            const err = await res.json();
            throw new Error(err.message);
        }
        
    } catch (error) {
        alert(error.message);
    }
}

