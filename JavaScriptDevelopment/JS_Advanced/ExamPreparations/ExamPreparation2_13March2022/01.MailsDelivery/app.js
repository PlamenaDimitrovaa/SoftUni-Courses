function solve() {
let recipientNameElement = document.getElementById('recipientName');
let titleElement = document.getElementById('title');
let messageElement = document.getElementById('message');

let addButtonElement = document.getElementById('add');

addButtonElement.addEventListener('click', (e) => {

    e.preventDefault();
    
    let recipient = recipientNameElement.value;
    let title = titleElement.value;
    let message = messageElement.value;

    recipientNameElement.value = '';
    titleElement.value = '';
    messageElement.value = '';

    if(!recipient || !title || !message){
        return;
    }

    let divListMailsElement = document.querySelector('.list-mails');
    let ulElement = document.getElementById('list');
    let liElement = document.createElement('li');
    let hForTitleElement = document.createElement('h4');
    let hForRecipientNameElement = document.createElement('h4');
    let spanElement = document.createElement('span');
    let divWithIdListActionElement = document.createElement('div');
    let sendButtonElement = document.createElement('button');
    let deleteButtonElement = document.createElement('button');
    
    hForTitleElement.textContent = `Title: ${title}`;
    hForRecipientNameElement.textContent = `Recipient Name: ${recipient}`;
    spanElement.textContent = `${message}`;
    liElement.appendChild(hForTitleElement);
    liElement.appendChild(hForRecipientNameElement);
    liElement.appendChild(spanElement);
    
    sendButtonElement.textContent = 'Send';
    deleteButtonElement.textContent = 'Delete';
    divWithIdListActionElement.appendChild(sendButtonElement);
    divWithIdListActionElement.appendChild(deleteButtonElement);
    liElement.appendChild(divWithIdListActionElement);
    ulElement.appendChild(liElement);
    divListMailsElement.appendChild(ulElement);

    
    deleteButtonElement.addEventListener('click', (e) => {
        e.preventDefault();
        let trashDivElement = document.querySelector('.trash');
             let trashUlElement = document.querySelector('.delete-list');
             let trashLiElement = document.createElement('li');
             let trashToSpanElement = document.createElement('span');
             let trashTitleSpanElement = document.createElement('span');
             trashToSpanElement.textContent = `To: ${recipient}`;
             trashTitleSpanElement.textContent = `Title: ${title}`;
             trashLiElement.appendChild(trashToSpanElement);
             trashLiElement.appendChild(trashTitleSpanElement);
             trashUlElement.appendChild(trashLiElement);
             trashDivElement.appendChild(trashUlElement);
         ulElement.removeChild(liElement);
    })
    
    sendButtonElement.addEventListener('click', (e) => {
        e.preventDefault();
        let divWithClassSentMails = document.querySelector('.sent-mails');
        let ulWithClassSentList = document.querySelector('.sent-list');
        let liElement2 = document.createElement('li');
        let tospan = document.createElement('span');
        let titlespan = document.createElement('span');
        tospan.textContent = `To: ${recipient}`;
        titlespan.textContent = `Title: ${title}`;
        liElement2.appendChild(tospan);
        liElement2.appendChild(titlespan);
        
         let divWithButtonDelete = document.createElement('div');
         let deleteButtonWithClassElement = document.createElement('button');
         deleteButtonWithClassElement.textContent = 'Delete';
         deleteButtonWithClassElement.classList.add('delete');
         divWithButtonDelete.appendChild(deleteButtonWithClassElement);
         liElement2.appendChild(divWithButtonDelete);
         ulWithClassSentList.appendChild(liElement2);
         divWithClassSentMails.appendChild(ulWithClassSentList);
         
         ulElement.removeChild(liElement);   
         
         deleteButtonWithClassElement.addEventListener('click', (e) => {
             e.preventDefault();
             let trashDivElement = document.querySelector('.trash');
             let trashUlElement = document.querySelector('.delete-list');
             let trashLiElement = document.createElement('li');
             let trashToSpanElement = document.createElement('span');
             let trashTitleSpanElement = document.createElement('span');
             trashToSpanElement.textContent = `To: ${recipient}`;
             trashTitleSpanElement.textContent = `Title: ${title}`;
             trashLiElement.appendChild(trashToSpanElement);
             trashLiElement.appendChild(trashTitleSpanElement);
             trashUlElement.appendChild(trashLiElement);
             trashDivElement.appendChild(trashUlElement);
             
             ulWithClassSentList.removeChild(liElement2);
            })
        })
    })
    
    let resetButtonElement = document.getElementById('reset');
    
    resetButtonElement.addEventListener('click', (e) => {
        e.preventDefault();
        console.log(resetButtonElement);
        recipientNameElement.value = '';
        titleElement.value = '';
        messageElement.value = '';
    })
}

solve()