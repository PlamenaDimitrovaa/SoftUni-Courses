import {router} from './router.js';

export function renderYears() {
    let yearsSection = document.getElementById('years');
    yearsSection.style.display = 'block';
    yearsSection.addEventListener('click', callRouter);
}

function callRouter(e) {
    let year = '';

    if (e.target.tagName === 'TD') {
        year = e.target.children[0].textContent;
    } else if(e.target.tagName === 'DIV'){
        year = e.target.textContent;
    } else {
        return;
    }

    let id = `year-${year}`;

    router(id);
}