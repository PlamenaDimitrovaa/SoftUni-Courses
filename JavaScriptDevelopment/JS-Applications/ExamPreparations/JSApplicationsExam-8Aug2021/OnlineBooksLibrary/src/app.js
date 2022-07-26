import { page } from './lib.js';
import * as api from './api/data.js';
import { homePage } from './views/home.js';
import decorateContext, { updateUserNav } from './middlewares/decorateContext.js';
import { loginPage } from './views/login.js';

window.api = api;

page(decorateContext);
page('/', homePage);    
page('/login', loginPage)

updateUserNav();
page.start();
