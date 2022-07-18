import { towns } from './towns.js';
import { html, render } from '../node_modules/lit-html/lit-html.js';

const main = document.body;

const searchTemp = (towns, match) => html`
<article>
   <div id="towns">
       <ul>
           ${towns.map(t => itemTemp(t, match))}
       </ul>
   </div>
   <input type="text" id="searchText" />
   <button @click=${search}>Search</button>
   <div id="result">${countMatches(towns, match)}</div>
</article>`;

const itemTemp = (name, match) => html`
<li class=${(match && name.toLowerCase().includes(match.toLowerCase())) ? 'active' : ''}>${name}</li>`;

update();

function update(match = ''){
   const result = searchTemp(towns, match);
   render(result, main);
   //document.getElementById('searchText').value = '';
}

function search() {
   const match = document.getElementById('searchText').value;

   update(match);
}

function countMatches(towns, match){
  const matches = towns.filter(t => match && t.toLowerCase().includes(match.toLowerCase())).length;
  return matches ? `${matches} matches found` : '';
}

