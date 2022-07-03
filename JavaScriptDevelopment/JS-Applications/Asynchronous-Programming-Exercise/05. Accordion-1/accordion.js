async function solution() {
   let url = `http://localhost:3030/jsonstore/advanced/articles/list`;
   let res = await fetch(url);
   let data = await res.json();

   let mainSection = document.getElementById('main');

   data.forEach(x => {
       let accordionDiv = document.createElement('div');
       accordionDiv.classList.add('accordion');

       let headDiv = document.createElement('div');
       headDiv.classList.add('head');

       let span = document.createElement('span');
       span.textContent = `${x.title}`;

       let moreBtn = document.createElement('button');
       moreBtn.classList.add('button');
       moreBtn.id = `${x._id}`;
       moreBtn.textContent = 'MORE';

       let extraDiv = document.createElement('div');
       extraDiv.classList.add('extra');
   
       let p = document.createElement('p');

       moreBtn.addEventListener('click', async (e) => {
        if(e.target.textContent === 'MORE'){
            let data = await getMoreInformation(x._id);
            p.textContent = data.content;

            e.target.textContent = 'LESS';
            extraDiv.classList.remove('extra');
        } else if(e.target.textContent === 'LESS'){
            e.target.textContent = 'MORE';
            extraDiv.classList.add('extra');
        }
       });

       extraDiv.appendChild(p);
       headDiv.appendChild(span);
       headDiv.appendChild(moreBtn);
       accordionDiv.appendChild(headDiv);
       accordionDiv.appendChild(extraDiv);
       mainSection.appendChild(accordionDiv);
    });

    async function getMoreInformation(id){
        let url = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;
        let res = await fetch(url);
        let data = await res.json();
        return data;
    }
}

solution();