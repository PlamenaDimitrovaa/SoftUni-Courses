window.addEventListener('load', solve);

function solve() {
    let genreElement = document.getElementById('genre');
    let nameElement = document.getElementById('name');
    let authorElement = document.getElementById('author');
    let dateElement = document.getElementById('date');
    let addButton = document.getElementById('add-btn');
    let allHitsContainerDiv = document.querySelector('.all-hits-container');


    addButton.addEventListener('click', (e) => {
        e.preventDefault();
        if(genreElement.value == '' || nameElement.value == '' || authorElement == '' || dateElement == ''){
            return;
        }

        let hitsInfoDiv = document.createElement('div');
        hitsInfoDiv.classList.add('hits-info');
        let image = document.createElement('img');
        image.setAttribute('src', './static/img/img.png');
    
        let genreH = document.createElement('h2');
        let nameH = document.createElement('h2');
        let authorH = document.createElement('h2');
        let dateH = document.createElement('h2');
    
        genreH.textContent = `Genre: ${genreElement.value}`;
        nameH.textContent = `Name: ${nameElement.value}`;
        authorH.textContent = `Author: ${authorElement.value}`;
        dateH.textContent = `Date: ${dateElement.value}`;
    
        let saveBtn = document.createElement('button');
        let likeBtn = document.createElement('button');
        let deleteBtn = document.createElement('button');
        saveBtn.textContent = "Save song";
        saveBtn.classList.add('save-btn');
        likeBtn.textContent = "Like song";
        likeBtn.classList.add('like-btn');
        deleteBtn.textContent = "Delete";
        deleteBtn.classList.add('delete-btn');

        hitsInfoDiv.appendChild(image);
        hitsInfoDiv.appendChild(genreH);
        hitsInfoDiv.appendChild(nameH);
        hitsInfoDiv.appendChild(authorH);
        hitsInfoDiv.appendChild(dateH);
        hitsInfoDiv.appendChild(saveBtn);
        hitsInfoDiv.appendChild(likeBtn);
        hitsInfoDiv.appendChild(deleteBtn);

        allHitsContainerDiv.appendChild(hitsInfoDiv);
        genreElement.value = "";
        nameElement.value = "";
        authorElement.value = "";
        dateElement.value = "";

        likeBtn.addEventListener('click', (e) => {
            e.preventDefault();
            let p = document.getElementsByTagName('p')[1].textContent;
            let count = p.split(': ')[1];
            count = Number(count + 1);
            let likesP = document.getElementsByTagName('p')[1];
            likesP.textContent = `Total Likes: ${Number(count)}`;
            e.target.disabled = true;
        })

        saveBtn.addEventListener('click', (e) => {
            e.preventDefault();
            let savedSong = document.querySelector('.saved-container');
            hitsInfoDiv.removeChild(saveBtn);
            hitsInfoDiv.removeChild(likeBtn);
            hitsInfoDiv.appendChild(image);
            hitsInfoDiv.appendChild(genreH);
            hitsInfoDiv.appendChild(nameH);
            hitsInfoDiv.appendChild(authorH);
            hitsInfoDiv.appendChild(dateH);
            hitsInfoDiv.appendChild(deleteBtn);
            savedSong.appendChild(hitsInfoDiv);

            deleteBtn.addEventListener('click', (e) => {
                e.preventDefault();
                savedSong.removeChild(hitsInfoDiv);
            })
        })
    })
}