import { editPost, getPostById } from '../api/posts.js';
import { html } from '../lib.js';

const editTemplate = (post, onSubmit) => html`
    <section id="edit">
        <div class="form">
        <h2>Edit Offer</h2>
        <form @submit=${onSubmit} class="edit-form">
            <input
            type="text"
            name="title"
            id="job-title"
            placeholder="Title"
            .value=${post.title}
            />
            <input
            type="text"
            name="imageUrl"
            id="job-logo"
            placeholder="Company logo url"
            .value=${post.imageUrl}
            />
            <input
            type="text"
            name="category"
            id="job-category"
            placeholder="Category"
            .value=${post.category}
            />
            <textarea
            id="job-description"
            name="description"
            placeholder="Description"
            rows="4"
            cols="50"
            .value=${post.description}
            ></textarea>
            <textarea
            id="job-requirements"
            name="requirements"
            placeholder="Requirements"
            rows="4"
            cols="50"
            .value=${post.requirements}
            ></textarea>
            <input
            type="text"
            name="salary"
            id="job-salary"
            placeholder="Salary"
            .value=${post.salary}
            />

            <button type="submit">post</button>
        </form>
        </div>
    </section>`;

export async function editView(ctx){
    const post = await getPostById(ctx.params.id);
    ctx.render(editTemplate(post, onSubmit));

    async function onSubmit(e){
        e.preventDefault();

        const formData = new FormData(e.target);
        const title = formData.get('title');
        const imageUrl = formData.get('imageUrl');
        const category = formData.get('category');
        const description = formData.get('description');
        const requirements = formData.get('requirements');
        let salary = formData.get('salary');

        
        if(title == '' || imageUrl == '' || category == '' || description == '' || requirements == '' || salary == ''){
            return alert('All fields are required!');
        }
        
       // salary = Number(salary);

        await editPost(ctx.params.id, {title, imageUrl, category, description, requirements, salary});
        e.target.reset();
        ctx.page.redirect(`/details/${ctx.params.id}`);
    }
}