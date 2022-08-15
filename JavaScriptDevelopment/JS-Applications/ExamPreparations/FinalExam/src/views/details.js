import { deletePost, getPostById } from '../api/posts.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (post, isOwner, onDelete) => html`
    <section id="details">
        <div id="details-wrapper">
        <img id="details-img" src="${post.imageUrl}" alt="example1" />
        <p id="details-title">${post.title}</p>
        <p id="details-category">
            Category: <span id="categories">${post.category}</span>
        </p>
        <p id="details-salary">
            Salary: <span id="salary-number">${post.salary}</span>
        </p>
        <div id="info-wrapper">
            <div id="details-description">
            <h4>Description</h4>
            <span>${post.description}</span>
            </div>
            <div id="details-requirements">
            <h4>Requirements</h4>
            <span>${post.requirements}</span>
            </div>
        </div>
        <!-- <p>Applications: <strong id="applications">1</strong></p> -->

        ${isOwner
            ? html`
             <div id="action-buttons">
                <a href="/edit/${post._id}" id="edit-btn">Edit</a>
                <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>

            <!--Bonus - Only for logged-in users ( not authors )-->
                <!-- <a href="" id="apply-btn">Apply</a> -->
            </div>`
            : ''
        }
        </div>
    </section>
`;

export async function detailsView(ctx){
    const post = await getPostById(ctx.params.id);
    const userData = getUserData();
    const isOwner = userData?.id == post._ownerId;
    ctx.render(detailsTemplate(post, isOwner, onDelete));

    async function onDelete(){
        const choice = confirm('Are you sure you want to delete this offert?');
        if(choice){
            await deletePost(ctx.params.id);
            ctx.page.redirect('/catalog');
        }
    }
}