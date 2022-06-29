async function solution() {
    const url = `http://localhost:3030/jsonstore/advanced/articles/list`;
    const result = await fetch(url);
    const data = await result.json();

    const main = document.getElementById('main');

    data.forEach(a => {
        const divAccordion = document.createElement('div');
        divAccordion.classList.add('accordion');

        const headDiv = document.createElement('div');
        headDiv.classList.add('head');

        const titleSpan = document.createElement('span');
        titleSpan.textContent = a.title;

        const moreButton = document.createElement('button');
        moreButton.classList.add('button');
        moreButton.setAttribute('id', a._id);
        moreButton.textContent = 'MORE';

        const extraDiv = document.createElement('div');
        extraDiv.classList.add('extra');
        const pElement = document.createElement('p');

        moreButton.addEventListener('click', async (e) => {
            if (e.target.textContent === 'MORE') {
                const data = await getMoreInformation(a._id);
                pElement.textContent = data.content;

                e.target.textContent = 'LESS';
                extraDiv.classList.remove('extra');
            } else if (e.target.textContent === 'LESS') {
                e.target.textContent = 'MORE';
                extraDiv.classList.add('extra');
            }
        });

        extraDiv.appendChild(pElement);
        headDiv.appendChild(titleSpan);
        headDiv.appendChild(moreButton);
        divAccordion.appendChild(headDiv);
        divAccordion.appendChild(extraDiv);
        main.appendChild(divAccordion);
    });

    async function getMoreInformation(id) {
        const url = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;
        const result = await fetch(url);
        const data = await result.json();

        return data;
    }
}

solution()