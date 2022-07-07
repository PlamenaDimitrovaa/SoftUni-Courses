const url = `http://localhost:3030/jsonstore/messenger`;
const messages = document.getElementById('messages');


function attachEvents(){
    document.getElementById('submit').addEventListener('click', postMessage);
    document.getElementById('refresh').addEventListener('click', loadMessages);
}

async function postMessage(e){
    e.preventDefault();

    const name = document.getElementById('author');
    const message = document.getElementById('content');

    if(name.value !== '' && message.value !== ''){

        let data = {
            author: name.value,
            content: message.value,
        }
    
        const res = await fetch(url, {
            method: 'post',
            headers: {
                'Content-type': 'application/json',
            },
            body: JSON.stringify(data),
        })
    
        name.value = '';
        message.value = '';
    }
}

async function loadMessages(e){
    e.preventDefault();

    const res = await fetch(url);
    const data = await res.json();

    const elements = Object.values(data);
    messages.value = elements.map(({author, content}) => `${author}: ${content}`).join('\n');

}

attachEvents();

//const url = 'http://localhost:3030/jsonstore/messenger'; 
// const messages = document.getElementById('messages');

// function attachEvents() {
//     const sendBtn = document.getElementById('submit');
//     const refreshBtn = document.getElementById('refresh');
    
//     sendBtn.addEventListener('click', onSubmit);
//     refreshBtn.addEventListener('click', onRefresh);
// }

// async function onSubmit(event){
//     event.preventDefault();

//     const [author, content] = [document.getElementById('author'), document.getElementById('content')];

//     if(author.value !== '' || content.value !== ''){
//         await request(url, {author: author.value, content: content.value});
//        // messages.value += `${author.value}: ${content.value}`;
//         author.value = '';
//         content.value = '';
//     }
// }

// async function onRefresh(event){
//     event.preventDefault();
//     const response = await fetch(url);
//     const data = await response.json();

//    let elements = Object.values(data);
//    messages.value = elements.map(({author, content}) => `${author}: ${content}`).join('\n');
// }

// async function request(url, option){
//     if(option){
//         option = {
//             method: 'post',
//             headers: {
//                 'Content-Type': 'application/json',
//             },
//             body: JSON.stringify(option),
//         }
//     }

//     const response = await fetch(url, option);
//     return response.json();
// }
