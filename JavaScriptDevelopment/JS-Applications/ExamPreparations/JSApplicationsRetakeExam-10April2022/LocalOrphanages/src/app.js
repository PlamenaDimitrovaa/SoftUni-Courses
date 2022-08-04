import { logout } from './api/users.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js';
import { createView } from './views/create.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { myPostsView } from './views/my-posts.js';
import { registerView } from './views/register.js';

const main = document.querySelector('#main-content');
document.querySelector('#logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/details/:id', detailsView);
page('/edit/:id', editView);
page('/my-posts', myPostsView);

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
        document.querySelector('#user').style.display = 'flex';
        document.querySelector('#guest').style.display = 'none';
    } else {
        document.querySelector('#user').style.display = 'none';
        document.querySelector('#guest').style.display = 'flex';
    }
}

function onLogout(){
    logout();
    updateNav();
    page.redirect('/');
}