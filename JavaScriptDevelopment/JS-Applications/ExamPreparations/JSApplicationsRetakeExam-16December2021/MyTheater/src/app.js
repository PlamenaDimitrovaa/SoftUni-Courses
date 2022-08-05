import { logout } from './api/users.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js';
import { createView } from './views/create.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { profileView } from './views/profile.js';
import { registerView } from './views/register.js';

const main = document.getElementById('content');
const logoutBtn = document.getElementById('logoutBtn');
logoutBtn.addEventListener('click', onLogout);

page(decorateContext);
page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/profile', profileView);
page('/edit/:id', editView);
page('/details/:id', detailsView);

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
        document.getElementById('user-profile').style.display = 'flex';
        document.getElementById('user-create').style.display = 'flex';
        logoutBtn.style.display = 'flex';
        document.getElementById('guest-login').style.display = 'none';
        document.getElementById('guest-register').style.display = 'none';
    } else {
        document.getElementById('user-profile').style.display = 'none';
        document.getElementById('user-create').style.display = 'none';
        document.getElementById('logoutBtn').style.display = 'none';
        document.getElementById('guest-login').style.display = 'flex';
        document.getElementById('guest-register').style.display = 'flex';
    }
}

function onLogout(){
    logout();
    updateNav();
    page.redirect('/');
}