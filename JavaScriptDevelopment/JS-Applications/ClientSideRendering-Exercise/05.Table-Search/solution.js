import { getAllStudents } from './api.js';
import { render } from '../node_modules/lit-html/lit-html.js';
import { studentsTemplate } from './studentsTemplate.js';
import { search } from './search.js';

let tableBody = document.querySelector('.container tbody');
let studentsData = await getAllStudents();

const template = studentsTemplate(Object.values(studentsData));
const searchBtn = document.getElementById('searchBtn');
searchBtn.addEventListener('click', search);
render(template, tableBody);

