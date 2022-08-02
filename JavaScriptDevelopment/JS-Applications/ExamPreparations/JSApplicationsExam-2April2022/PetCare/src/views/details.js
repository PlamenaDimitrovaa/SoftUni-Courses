import { getAnimalById } from '../api/animals.js';
import { html } from '../lib.js';

const detailsTemplate = (animal) => html`
    <section id="detailsPage">
        <div class="details">
            <div class="animalPic">
                <img src="${animal.image}">
            </div>
            <div>
                <div class="animalInfo">
                    <h1>Name: ${animal.name}</h1>
                    <h3>Breed: ${animal.breed}</h3>
                    <h4>Age: ${animal.age} years</h4>
                    <h4>Weight: ${animal.weight}kg</h4>
                    <!-- <h4 class="donation">Donation: 0$</h4> -->
                </div>
                <!-- if there is no registered user, do not display div-->
                <div class="actionBtn">
                    <!-- Only for registered user and creator of the pets-->
                    <a href="#" class="edit">Edit</a>
                    <a href="#" class="remove">Delete</a>
                    <!--(Bonus Part) Only for no creator and user-->
                    <!-- <a href="#" class="donate">Donate</a> -->
                </div>
            </div>
        </div>
    </section>`

export async function detailsView(ctx){
    const animal = await getAnimalById(ctx.params.id);
    ctx.render(detailsTemplate(animal));
}