import { router } from './router.js';

export function renderCurrYear(id) {
    let currYearSection = document.getElementById(id);
    currYearSection.style.display = 'block';
    currYearSection.addEventListener('click', (e) => callRouter(e, id));
}

function callRouter(e, id) {
    let year = id.split('-')[1];
    let monthNumber = 0;
    let resultId = null;

    if (e.target.tagName === 'CAPTION') {
        router('home');
        return;
    } else if (e.target.tagName === 'TD') {
        monthNumber = monthNumberObj[e.target.children[0].textContent];
    } else if (e.target.tagName === 'DIV') {
        monthNumber = monthNumberObj[e.target.textContent];
    } else {
        return;
    }

    resultId = `month-${year}-${monthNumber}`;
    router(resultId);
}

const monthNumberObj = {
    'Jan': 1, 
    'Feb': 2, 
    'Mar': 3, 
    'Apr': 4, 
    'May': 5, 
    'Jun': 6, 
    'Jul': 7,
    'Aug': 8, 
    'Sept': 9, 
    'Oct': 10, 
    'Nov': 11, 
    'Dec': 12
};