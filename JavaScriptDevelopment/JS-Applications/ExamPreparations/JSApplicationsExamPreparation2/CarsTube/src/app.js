import { logout } from './api/users.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js';
import { catalogView } from './views/catalog.js';
import { createView } from './views/create.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { myListingsView } from './views/my-listings.js';
import { registerView } from './views/register.js';
import { searchView } from './views/search.js';

const main = document.getElementById('site-content');
const logoutBtn = document.getElementById('logoutBtn');
logoutBtn.addEventListener('click', onLogout);

page(decorateContext);
page('/', homeView);
page('/catalog', catalogView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/details/:id', detailsView);
page('/edit/:id', editView);
page('/my-listings', myListingsView);
page('/search', searchView);

updateNav();
page.start();

function renderMain(data){
    render(data, main);
}

function decorateContext(ctx, next){
    ctx.render = renderMain;
    ctx.updateNav = updateNav;
    next();
}

function updateNav(){
    const userData = getUserData();
    if(userData){
        document.getElementById('profile').style.display = "flex";
        document.getElementById('guest').style.display = "none";
        document.querySelector('#profile a').textContent = `Welcome ${userData.username}`;
    } else {
        document.getElementById('profile').style.display = "none";
        document.getElementById('guest').style.display = "flex";
    }
}

function onLogout(){
    logout();
    updateNav();
    page.redirect('/');
}