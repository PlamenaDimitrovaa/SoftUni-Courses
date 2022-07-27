import { page } from './lib.js';
import * as api from './api/data.js';
import { homePage } from './views/home.js';
import decorateContext, { updateUserNav } from './middlewares/decorateContext.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { editPage } from './views/edit.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { myBooksPage } from './views/my-books.js';

window.api = api;

page(decorateContext);
page('/', homePage);    
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage);
page('/edit/:id', editPage);
page('/details/:id', detailsPage);
page('/my-books', myBooksPage);

updateUserNav();
page.start();
