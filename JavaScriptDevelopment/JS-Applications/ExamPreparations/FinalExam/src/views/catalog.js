import { getAllPosts } from '../api/posts.js';
import { html } from '../lib.js';

const catalogTemplate = (posts) => html`
    <section id="dashboard">
        <h2>Job Offers</h2>
        ${posts.length == 0
            ? html`<h2>No offers yet.</h2>`
            : posts.map(postCard)
        }
    </section>`

const postCard = (post) => html`
<div class="offer">
<img src="${post.imageUrl}" alt="./images/example3.png" />
    <p>
        <strong>Title: </strong
        ><span class="title">${post.title}</span>
    </p>
<p><strong>Salary:</strong><span class="salary">${post.salary}</span></p>
<a class="details-btn" href="/details/${post._id}">Details</a>
</div> `

export async function catalogView(ctx){
    const posts = await getAllPosts();
    ctx.render(catalogTemplate(posts));
}