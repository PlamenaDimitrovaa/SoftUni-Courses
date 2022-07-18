import { html, render } from '../node_modules/lit-html/lit-html.js';

const loadBtn = document.getElementById('btnLoadTowns');

loadBtn.addEventListener('click', getTowns);

const temp = (data) => html`
<ul>
  ${data.map(t => html`<li>${t}</li>`)}
</ul>`;

function getTowns(e){
    e.preventDefault();
    if(document.getElementById('towns').value !== ''){
        const rootDiv = document.getElementById('root');
        const towns = document.getElementById('towns').value.split(', ');
       
        const result = temp(towns);
        render(result, rootDiv);
        document.getElementById('towns').value = '';
    }
}

