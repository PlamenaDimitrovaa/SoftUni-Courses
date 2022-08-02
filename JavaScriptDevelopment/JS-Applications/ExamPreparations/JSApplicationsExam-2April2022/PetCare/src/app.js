import { render, page } from './lib.js';
import { getUserData } from './util.js';
import { catalogView } from './views/catalog.js';
import { createView } from './views/create.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { logoutView } from './views/logout.js';
import { registerView } from './views/register.js';

const main = document.getElementById('content');

page(decorateContext);
page('/', homeView);
page('/catalog', catalogView);
page('/create', createView);
page('/login', loginView);
page('/register', registerView);
page('/logout', logoutView)
page('/details/:id', detailsView);
page('/edit/:id', editView);

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
       document.getElementById('user-create').style.display = 'flex';
       document.getElementById('user-logout').style.display = 'flex';
       document.getElementById('guest-login').style.display = 'none';
       document.getElementById('guest-register').style.display = 'none';
    } else {
        document.getElementById('user-create').style.display = 'none';
        document.getElementById('user-logout').style.display = 'none';
        document.getElementById('guest-login').style.display = 'flex';
        document.getElementById('guest-register').style.display = 'flex';
    }
}

