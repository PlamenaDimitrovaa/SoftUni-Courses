import { deleteAnimalById, getAnimalById } from '../api/animals.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (animal, isOwner, onDelete, userData) => html`
    <section id="detailsPage">
        <div class="details">
            <div class="animalPic">
                <img src="${animal.image}">
            </div>
            <div>
                <div class="animalInfo">
                    <h1>Name: ${animal.name}</h1>
                    <h3>Breed: ${animal.breed}</h3>
                    <h4>Age: ${animal.age}</h4>
                    <h4>Weight: ${animal.weight}</h4>
                    <h4 class="donation">Donation: 0$</h4>
                </div>
                ${isOwner
                    ? html`
                    <div class="actionBtn">
                        <a href="/edit/${animal._id}" class="edit">Edit</a>
                        <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>
                    </div>`
                    : ''
                }

                ${userData && !isOwner
                    ? html`<a href="#" class="donate">Donate</a>`
                    : ''
                }
                
            </div>
        </div>
    </section>`

export async function detailsView(ctx){
    const userData = getUserData();
    const animal = await getAnimalById(ctx.params.id);
    const isOwner = userData?.id == animal._ownerId;

    async function onDelete(){
        const choice = confirm(`Are you sure you want to delete this ${animal.name}?`);
        if(choice){
            await deleteAnimalById(animal._id);
            ctx.page.redirect('/');
        }
    }
    ctx.render(detailsTemplate(animal, isOwner, onDelete, userData));
}