import { renderYears } from "./years.js"
import { renderCurrYear } from "./year.js"
import { renderCurrMonth } from "./month.js"

const routes = {
    'home': renderYears,
    'year': renderCurrYear,
    'month': renderCurrMonth
}

export function router(id) {
    let render = null;
    hideAllSections();

    if (id.includes('year')) {
        render = routes['year'];
        render(id);
    } else if (id.includes('month')) {
        render = routes['month'];
        render(id);
    } else if (id.includes('home')) {
        render = routes['home'];
        render();
    }
}

function hideAllSections() {
    let allSections = document.querySelectorAll('section');
    Array.from(allSections).forEach(s => {
        s.style.display = 'none';
    });
}