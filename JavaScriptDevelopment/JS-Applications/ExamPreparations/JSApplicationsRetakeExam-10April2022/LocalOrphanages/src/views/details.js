import { deletePost, getPostById } from '../api/orphanages.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (post, isOwner, userData, onDelete) => html`
    <section id="details-page">
        <h1 class="title">Post Details</h1>

        <div id="container">
            <div id="details">
                <div class="image-wrapper">
                    <img src="${post.imageUrl}" alt="Material Image" class="post-image">
                </div>
                <div class="info">
                    <h2 class="title post-title">${post.title}</h2>
                    <p class="post-description">Description: ${post.description}</p>
                    <p class="post-address">Address: ${post.address}</p>
                    <p class="post-number">Phone number: ${post.phone}</p>
                    <p class="donate-Item">Donate Materials: 0</p>

                    ${userData && isOwner
                        ? html`
                            <div class="btns">
                                <a href="/edit/${post._id}" class="edit-btn btn">Edit</a>
                                <a @click=${onDelete} href="javascript:void(0)" class="delete-btn btn">Delete</a>

                            <!--Bonus - Only for logged-in users ( not authors )-->
                                <!-- <a href="#" class="donate-btn btn">Donate</a> -->
                            </div>`
                        : ''
                    }
                </div>
            </div>
        </div>
    </section>`;

export async function detailsView(ctx){
    const userData = getUserData();
    const post = await getPostById(ctx.params.id);
    const isOwner = userData?.id == post._ownerId;
    ctx.render(detailsTemplate(post, isOwner, userData, onDelete));

    async function onDelete(){
        const choice = confirm('Are you sure you want to delete it?');
        if(choice){
            await deletePost(ctx.params.id);
            ctx.page.redirect('/');
        }
    }
}