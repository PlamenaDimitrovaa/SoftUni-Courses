import { logout } from "../api/users.js";

export function logoutView(ctx){
    logout();
    ctx.updateNav();
    ctx.page.redirect('/');
}