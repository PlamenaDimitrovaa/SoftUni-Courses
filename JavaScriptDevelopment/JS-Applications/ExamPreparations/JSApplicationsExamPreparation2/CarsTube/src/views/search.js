import { searchCar } from '../api/cars.js';
import { html } from '../lib.js';

const searchTemplate = (searchHandler, cars) => html`
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button @click=${searchHandler} class="button-list">Search</button>
    </div>

    <h2>Results:</h2>
    <div class="listings">
        ${cars.length == 0
            ? html`<p class="no-cars"> No results.</p>`
            : cars.map(carCard)
        }
    </div>
</section>
`;

const carCard = (car) => html`
    <div class="listing">
        <div class="preview">
            <img src="${car.imageUrl}">
        </div>
        <h2>${car.brand} ${car.model}</h2>
        <div class="info">
            <div class="data-info">
                <h3>Year: ${car.year}</h3>
                <h3>Price: ${car.price} $</h3>
            </div>
            <div class="data-buttons">
                <a href="/details/${car._id}" class="button-carDetails">Details</a>
            </div>
        </div>
    </div>
`

export const searchView = (ctx) => {
    async function searchHandler(e){
        let searchElement = document.getElementById('search-input');
        const cars = await searchCar(searchElement.value)
        ctx.render(searchTemplate(searchHandler, cars));
    }

    ctx.render(searchTemplate(searchHandler, []));
}