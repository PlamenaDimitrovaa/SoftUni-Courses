import { getMyPosts } from '../api/orphanages.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const myPostsTemplate = (posts) => html`
    <section id="my-posts-page">
        <h1 class="title">My Posts</h1>
        ${posts.length == 0
            ? html`<h1 class="title no-posts-title">You have no posts yet!</h1>`
            : html`
                <div class="my-posts">
                    ${posts.map(postCard)}
                 </div>`
        }
    </section>`;

const postCard = (post) => html`
    <div class="post">
        <h2 class="post-title">${post.title}</h2>
        <img class="post-image" src="${post.imageUrl}" alt="Material Image">
        <div class="btn-wrapper">
            <a href="/details/${post._id}" class="details-btn btn">Details</a>
        </div>
    </div>`;

export async function myPostsView(ctx){
    const userData = getUserData();
    const posts = await getMyPosts(userData.id);
    ctx.render(myPostsTemplate(posts));
}