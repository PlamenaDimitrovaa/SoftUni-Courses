import { editCar, getCarById } from '../api/cars.js';
import { html } from '../lib.js';

const editTemplate = (car, onSubmit) => html`
    <section id="edit-listing">
    <div class="container">

        <form @submit=${onSubmit} id="edit-form">
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" .value="${car.brand}">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" .value="${car.model}">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" .value="${car.description}">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" .value="${car.year}">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" .value="${car.imageUrl}">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" .value="${car.price}">

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
    </section>`;

export async function editView(ctx){
    const car = await getCarById(ctx.params.id);
    ctx.render(editTemplate(car, onSubmit));

    async function onSubmit(e){
        e.preventDefault();

        const formData = new FormData(e.target);
        const brand = formData.get('brand');
        const model = formData.get('model');
        const description = formData.get('description');
        let year = formData.get('year');
        const imageUrl = formData.get('imageUrl');
        let price = formData.get('price');

        if(brand == '' || model == '' || description == '' || year == '' || imageUrl == '' || price == ''){
            return alert('All fields are required!');
        }

        year = Number(year);
        price = Number(price);

        // if(price <= 0 || year <= 0){
        //     return alert('Price and Year should be positive numbers!');
        // }

        await editCar(ctx.params.id, {brand, model, description, year, imageUrl, price});
        e.target.reset();
        ctx.page.redirect(`/details/${ctx.params.id}`);
    }
}