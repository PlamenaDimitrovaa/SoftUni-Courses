import {router} from './router.js';

export function renderCurrMonth(id) {
    debugger;
    let monthSection = document.getElementById(id);
    monthSection.style.display = 'block';
    document.querySelector(`#${id} caption`).addEventListener('click', (e) => callRouter(e, id));
}

function callRouter(e, id) {
    let year = id.split('-')[1];
    if (e.target.tagName === 'CAPTION') {
        router(`year-${year}`);
    } else {
        return;
    }
}
