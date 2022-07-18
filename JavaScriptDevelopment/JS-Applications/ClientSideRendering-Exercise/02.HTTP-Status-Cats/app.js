import { cats } from './catSeeder.js';
import { html, render } from '../node_modules/lit-html/lit-html.js';
import { styleMap } from '../node_modules/lit-html/directives/style-map.js';

const section = document.getElementById('allCats');

section.addEventListener('click', toggle);
const temp = (data) => html`
<ul>
    ${data.map(c => html`
    <li>
        <img src="./images/${c.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
        <div class="info">
            <button class="showBtn">${c.info ? 'Hide' : 'Show'} status code</button>
            <div class="status" style=${styleMap(c.info ? {display:'block'} : {display:'none'})}}} id="${c.id}">
                <h4>Status Code: ${c.statusCode}</h4>
                <p>${c.statusMessage}</p>
            </div>
        </div>
    </li>`)};
</ul>`;

cats.forEach(c => c.info = false);
update();

function toggle(e){

    e.preventDefault();
    const elementId = e.target.parentNode.querySelector('.status').id;
    const cat = cats.find(c => c.id == elementId);
    cat.info = !(cat.info);
    update();
}

function update(){
    const result = temp(cats);
    render(result, section);
}