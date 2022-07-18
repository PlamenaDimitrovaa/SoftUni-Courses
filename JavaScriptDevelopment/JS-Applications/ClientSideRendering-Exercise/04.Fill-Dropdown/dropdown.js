import { html, render } from '../node_modules/lit-html/lit-html.js';

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';

async function getOptions(){
    const response = await fetch(url);
    const data = await response.json();
    return data;
}

const selectTemplate = (data) => html`
    <select id="menu">
        ${data.map(el => html`<option value=${el._id}>${el.text}</option>`)}
    </select>`;

const options = Object.values(await getOptions());
console.log(options);

const main = document.querySelector('div');

update(options);

function update(options){
    const result = selectTemplate(options);
    render(result, main);
}

document.querySelector('form').addEventListener('submit', addItem);

async function addItem(e) {
    e.preventDefault();
    const text = document.getElementById('itemText').value;

    if(options.find(x => x.text == text)){
        alert('You cannot repeat towns!');
        document.getElementById('itemText').value = '';
        throw new Error('You cannot repeat towns!');
    }

    if(text == ''){
        alert('Field is required!');
        throw new Error('Field is required!');
    }

    const response = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({text}),
    })

    options.push(await response.json());

    update(options);

    document.getElementById('itemText').value = '';
}