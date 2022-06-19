window.addEventListener('load', solve);

function solve(){
    let genreElement = document.getElementById('genre');
    let nameElement = document.getElementById('name');
    let authorElement = document.getElementById('author');
    let dateElement = document.getElementById('date');

    let addBtn = document.getElementById('add-btn');

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();

        let genre = genreElement.value;
        let name = nameElement.value;
        let author = authorElement.value;
        let date = dateElement.value;

        if(genre == '' || name == '' || author == '' || date == ''){
            return;
        }

        let allhitscontainerDiv = document.querySelector('.all-hits-container');

        let hitsInfoDiv = document.createElement('div');
        hitsInfoDiv.className = 'hits-info';
        let image = document.createElement('img');
        image.setAttribute('src', './static/img/img.png');
        let genreH2 = document.createElement('h2');
        genreH2.textContent = `Genre: ${genre}`;
        let nameH2 = document.createElement('h2');
        nameH2.textContent = `Name: ${name}`;
        let authorH2 = document.createElement('h2');
        authorH2.textContent = `Author: ${author}`;
        let dateH3 = document.createElement('h3');
        dateH3.textContent = `Date: ${date}`;

        let saveSongbtn = document.createElement('button');
        saveSongbtn.className = 'save-btn';
        saveSongbtn.textContent = 'Save song';
        
        let likeSongbtn = document.createElement('button');
        likeSongbtn.className = 'like-btn';
        likeSongbtn.textContent = 'Like song';
        
        let likes = 0;
        let likesDiv = document.querySelector('.likes');
        let pWithTotalLikes = likesDiv.querySelector('p');

        likeSongbtn.addEventListener('click', (e) => {
            e.preventDefault();
            likes++;
            pWithTotalLikes.textContent = `Total Likes: ${likes}`;
            likeSongbtn.disabled = true;
        })

        let deleteSongbtn = document.createElement('button');
        deleteSongbtn.className = 'delete-btn';
        deleteSongbtn.textContent = 'Delete';
        
        hitsInfoDiv.appendChild(image);
        hitsInfoDiv.appendChild(genreH2);
        hitsInfoDiv.appendChild(nameH2);
        hitsInfoDiv.appendChild(authorH2);
        hitsInfoDiv.appendChild(dateH3);
        hitsInfoDiv.appendChild(saveSongbtn);
        hitsInfoDiv.appendChild(likeSongbtn);
        hitsInfoDiv.appendChild(deleteSongbtn);
        
        allhitscontainerDiv.appendChild(hitsInfoDiv);
        
        deleteSongbtn.addEventListener('click', (e) => {
            e.preventDefault();
            allhitscontainerDiv.removeChild(hitsInfoDiv);
        })
        
        saveSongbtn.addEventListener('click', (e) => {
            e.preventDefault();
            let savedContainerDiv = document.querySelector('.saved-container');
            hitsInfoDiv.removeChild(saveSongbtn);
            hitsInfoDiv.removeChild(likeSongbtn);

            savedContainerDiv.appendChild(hitsInfoDiv);
            allhitscontainerDiv.firstChild.remove();

            deleteSongbtn.addEventListener('click', (e) => {
                e.preventDefault();
                savedContainerDiv.removeChild(hitsInfoDiv);
            })
        })
        
        genreElement.value = '';
        nameElement.value = '';
        authorElement.value = '';
        dateElement.value = '';
    })
}

// function solve() {
//     let genreElement = document.getElementById('genre');
//     let nameElement = document.getElementById('name');
//     let authorElement = document.getElementById('author');
//     let dateElement = document.getElementById('date');
//     let addButton = document.getElementById('add-btn');
//     let allHitsContainerDiv = document.querySelector('.all-hits-container');


//     addButton.addEventListener('click', (e) => {
//         e.preventDefault();
//         if(genreElement.value == '' || nameElement.value == '' || authorElement == '' || dateElement == ''){
//             return;
//         }

//         let hitsInfoDiv = document.createElement('div');
//         hitsInfoDiv.classList.add('hits-info');
//         let image = document.createElement('img');
//         image.setAttribute('src', './static/img/img.png');
    
//         let genreH = document.createElement('h2');
//         let nameH = document.createElement('h2');
//         let authorH = document.createElement('h2');
//         let dateH = document.createElement('h3');
    
//         genreH.textContent = `Genre: ${genreElement.value}`;
//         nameH.textContent = `Name: ${nameElement.value}`;
//         authorH.textContent = `Author: ${authorElement.value}`;
//         dateH.textContent = `Date: ${dateElement.value}`;
    
//         let saveBtn = document.createElement('button');
//         let likeBtn = document.createElement('button');
//         let deleteBtn = document.createElement('button');
//         saveBtn.textContent = "Save song";
//         saveBtn.classList.add('save-btn');
//         likeBtn.textContent = "Like song";
//         likeBtn.classList.add('like-btn');
//         deleteBtn.textContent = "Delete";
//         deleteBtn.classList.add('delete-btn');

//         hitsInfoDiv.appendChild(image);
//         hitsInfoDiv.appendChild(genreH);
//         hitsInfoDiv.appendChild(nameH);
//         hitsInfoDiv.appendChild(authorH);
//         hitsInfoDiv.appendChild(dateH);
//         hitsInfoDiv.appendChild(saveBtn);
//         hitsInfoDiv.appendChild(likeBtn);
//         hitsInfoDiv.appendChild(deleteBtn);

//         allHitsContainerDiv.appendChild(hitsInfoDiv);
//         genreElement.value = "";
//         nameElement.value = "";
//         authorElement.value = "";
//         dateElement.value = "";

//         likeBtn.addEventListener('click', (e) => {
//             e.preventDefault();
//             let p = document.getElementsByTagName('p')[1].textContent;
//             let count = p.split(': ')[1];
//             count = Number(count + 1);
//             let likesP = document.getElementsByTagName('p')[1];
//             likesP.textContent = `Total Likes: ${Number(count)}`;
//             e.target.disabled = true;
//         })

//         saveBtn.addEventListener('click', (e) => {
//             e.preventDefault();
//             let savedSong = document.querySelector('.saved-container');
//             hitsInfoDiv.removeChild(saveBtn);
//             hitsInfoDiv.removeChild(likeBtn);
//             hitsInfoDiv.appendChild(image);
//             hitsInfoDiv.appendChild(genreH);
//             hitsInfoDiv.appendChild(nameH);
//             hitsInfoDiv.appendChild(authorH);
//             hitsInfoDiv.appendChild(dateH);
//             hitsInfoDiv.appendChild(deleteBtn);
//             savedSong.appendChild(hitsInfoDiv);

//             deleteBtn.addEventListener('click', (e) => {
//                 e.preventDefault();
//                 savedSong.removeChild(hitsInfoDiv);
//             })
//         })
//     })
// }