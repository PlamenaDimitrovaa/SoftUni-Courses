function solve() {
    let recipientNameElement = document.getElementById('recipientName');
    let titleElement = document.getElementById('title');
    let messageElement = document.getElementById('message');

    let addBtn = document.getElementById('add');
    let resetBtn = document.getElementById('reset');
    
    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        if(recipientNameElement.value !== '' || titleElement.value !== '' || messageElement.value !== '' 
            || recipientNameElement.value || titleElement.value || messageElement.value){

            let name = recipientNameElement.value;
            let title = titleElement.value;
            let message = messageElement.value;
    
            let listMailsDiv = document.querySelector('.list-mails');
            let listUl = document.getElementById('list');
    
            let li = document.createElement('li');
            let titleh4 = document.createElement('h4');
            titleh4.textContent = `Title: ${title}`;
            let nameh4 = document.createElement('h4');
            nameh4.textContent = `Recipient Name: ${name}`;
            let span = document.createElement('span');
            span.textContent = `${message}`;
            
            let listActionDiv = document.createElement('div');
            listActionDiv.setAttribute('id', 'list-action');
            
            let sendBtn = document.createElement('button');
            sendBtn.setAttribute('type', 'submit');
            sendBtn.setAttribute('id', 'send');
            sendBtn.textContent = 'Send';
    
            sendBtn.addEventListener('click', (e) => {
                e.preventDefault();

                let sentMailsDiv = document.querySelector('.sent-mails');
                let sentListUl = document.querySelector('.sent-list');
    
                let sentLi = document.createElement('li');
                let toSpan = document.createElement('span');
                toSpan.textContent = `To: ${name}`;
                let titleSpan = document.createElement('span');
                titleSpan.textContent = `Title: ${title}`;
                let btnDiv = document.createElement('div');
                btnDiv.className = 'btn';
    
                let deleteBtn = document.createElement('button');
                deleteBtn.setAttribute('type', 'submit');
                deleteBtn.className = 'delete';
                deleteBtn.textContent = 'Delete';
    
                sentLi.appendChild(toSpan);
                sentLi.appendChild(titleSpan);
                btnDiv.appendChild(deleteBtn);
                sentLi.appendChild(btnDiv);
    
                sentListUl.appendChild(sentLi);
                sentMailsDiv.appendChild(sentListUl);
                li.remove();
                
                deleteBtn.addEventListener('click', (e) => {
                    e.preventDefault();
                    let trashDiv = document.querySelector('.trash');
                    let deleteListUl = document.querySelector('.delete-list');
                    let deleteLi = document.createElement('li');
                    
                    deleteLi.appendChild(toSpan);
                    deleteLi.appendChild(titleSpan);
                    deleteListUl.appendChild(deleteLi);
                    trashDiv.appendChild(deleteListUl);
                    
                    sentLi.remove();
                })
            })
            
            let deleteBtn = document.createElement('button');
            deleteBtn.setAttribute('type', 'submit');
            deleteBtn.setAttribute('id', 'delete');
            deleteBtn.textContent = 'Delete';
            
            listActionDiv.appendChild(sendBtn);
            listActionDiv.appendChild(deleteBtn);
    
            li.appendChild(titleh4);
            li.appendChild(nameh4);
            li.appendChild(span);
            li.append(listActionDiv);
    
            listUl.appendChild(li);
            listMailsDiv.appendChild(listUl);
    
            deleteBtn.addEventListener('click', (e) => {
                e.preventDefault();
                let trashDiv = document.querySelector('.trash');
                let deleteListUl = document.querySelector('.delete-list');
                let deleteLi = document.createElement('li');
                let toSpan = document.createElement('span');
                toSpan.textContent = `To: ${name}`;
                let titleSpan = document.createElement('span');
                titleSpan.textContent = `Title: ${title}`;
    
                deleteLi.appendChild(toSpan);
                deleteLi.appendChild(titleSpan);
                deleteListUl.appendChild(deleteLi);
                trashDiv.appendChild(deleteListUl);
                li.remove();
            })
    
            recipientNameElement.value = '';
            titleElement.value = '';
            messageElement.value = '';
        }
    })

    resetBtn.addEventListener('click', (e) => {
        e.preventDefault();
        recipientNameElement.value = '';
        titleElement.value = '';
        messageElement.value = '';
    })
}
solve();    

// function solve() {
//     let recipientNameElement = document.getElementById('recipientName');
//     let titleElement = document.getElementById('title');
//     let messageElement = document.getElementById('message');
    
//     let addButtonElement = document.getElementById('add');
    
//     addButtonElement.addEventListener('click', (e) => {
    
//         e.preventDefault();
        
//         let recipient = recipientNameElement.value;
//         let title = titleElement.value;
//         let message = messageElement.value;
    
//         recipientNameElement.value = '';
//         titleElement.value = '';
//         messageElement.value = '';
    
//         if(!recipient || !title || !message || recipient == '' || title == '' || message == ''){
//             return;
//         }
    
//         let divListMailsElement = document.querySelector('.list-mails');
//         let ulElement = document.getElementById('list');
//         let liElement = document.createElement('li');
//         let hForTitleElement = document.createElement('h4');
//         let hForRecipientNameElement = document.createElement('h4');
//         let spanElement = document.createElement('span');
//         let divWithIdListActionElement = document.createElement('div');
//         divWithIdListActionElement.setAttribute('id', 'list-action')
//         let sendButtonElement = document.createElement('button');
//         sendButtonElement.setAttribute('type', 'submit');
//         let deleteButtonElement = document.createElement('button');
//         deleteButtonElement.setAttribute('type', 'submit');

        
//         hForTitleElement.textContent = `Title: ${title}`;
//         hForRecipientNameElement.textContent = `Recipient Name: ${recipient}`;
//         spanElement.textContent = `${message}`;
//         liElement.appendChild(hForTitleElement);
//         liElement.appendChild(hForRecipientNameElement);
//         liElement.appendChild(spanElement);
        
//         sendButtonElement.textContent = 'Send';
//         deleteButtonElement.textContent = 'Delete';
//         divWithIdListActionElement.appendChild(sendButtonElement);
//         divWithIdListActionElement.appendChild(deleteButtonElement);
//         liElement.appendChild(divWithIdListActionElement);
//         ulElement.appendChild(liElement);
//         divListMailsElement.appendChild(ulElement);
    
        
//         deleteButtonElement.addEventListener('click', (e) => {
//             e.preventDefault();
//             let trashDivElement = document.querySelector('.trash');
//                  let trashUlElement = document.querySelector('.delete-list');
//                  let trashLiElement = document.createElement('li');
//                  let trashToSpanElement = document.createElement('span');
//                  let trashTitleSpanElement = document.createElement('span');
//                  trashToSpanElement.textContent = `To: ${recipient}`;
//                  trashTitleSpanElement.textContent = `Title: ${title}`;
//                  trashLiElement.appendChild(trashToSpanElement);
//                  trashLiElement.appendChild(trashTitleSpanElement);
//                  trashUlElement.appendChild(trashLiElement);
//                  trashDivElement.appendChild(trashUlElement);
//                  ulElement.removeChild(liElement);
//         })
        
//         sendButtonElement.addEventListener('click', (e) => {
//             e.preventDefault();
//             let divWithClassSentMails = document.querySelector('.sent-mails');
//             let ulWithClassSentList = document.querySelector('.sent-list');
//             let liElement2 = document.createElement('li');
//             let tospan = document.createElement('span');
//             let titlespan = document.createElement('span');
//             tospan.textContent = `To: ${recipient}`;
//             titlespan.textContent = `Title: ${title}`;
//             liElement2.appendChild(tospan);
//             liElement2.appendChild(titlespan);
            
//              let divWithButtonDelete = document.createElement('div');
//              divWithButtonDelete.classList.add('btn');
//              let deleteButtonWithClassElement = document.createElement('button');
//              deleteButtonWithClassElement.textContent = 'Delete';
//              deleteButtonWithClassElement.classList.add('delete');
//              deleteButtonWithClassElement.setAttribute("type", "submit");
//              divWithButtonDelete.appendChild(deleteButtonWithClassElement);
//              liElement2.appendChild(divWithButtonDelete);
//              ulWithClassSentList.appendChild(liElement2);
//              divWithClassSentMails.appendChild(ulWithClassSentList);
             
//              ulElement.removeChild(liElement);   
             
//              deleteButtonWithClassElement.addEventListener('click', (e) => {
//                  e.preventDefault();
//                  let trashDivElement = document.querySelector('.trash');
//                  let trashUlElement = document.querySelector('.delete-list');
//                  let trashLiElement = document.createElement('li');
//                  let trashToSpanElement = document.createElement('span');
//                  let trashTitleSpanElement = document.createElement('span');
//                  trashToSpanElement.textContent = `To: ${recipient}`;
//                  trashTitleSpanElement.textContent = `Title: ${title}`;
//                  trashLiElement.appendChild(trashToSpanElement);
//                  trashLiElement.appendChild(trashTitleSpanElement);
//                  trashUlElement.appendChild(trashLiElement);
//                  trashDivElement.appendChild(trashUlElement);
                 
//                  ulWithClassSentList.removeChild(liElement2);
//                 })
//             })
//         })
        
//         let resetButtonElement = document.getElementById('reset');
        
//         resetButtonElement.addEventListener('click', (e) => {
//             e.preventDefault();
//             console.log(resetButtonElement);
//             recipientNameElement.value = '';
//             titleElement.value = '';
//             messageElement.value = '';
//         })
//     }