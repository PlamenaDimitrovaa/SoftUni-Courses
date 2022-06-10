function solve() {
    let recipientNameElement = document.getElementById('recipientName');
    let titleElement = document.getElementById('title');
    let messageElement = document.getElementById('message');
    let addButton = document.getElementById('add');
    let resetButton = document.getElementById('reset');
    let listMailsDiv = document.querySelector('.list-mails');
    let ul = document.getElementById('list');
    let trashDiv = document.querySelector('.trash');
    let deleteListUl = document.querySelector('.delete-list');


    addButton.addEventListener('click', (e) => {
        e.preventDefault();
        if(!recipientNameElement || !titleElement || !messageElement){
            return;
        }

        // recipientNameElement.value = '';
        // titleElement.value = '';
        // messageElement.value = '';
    
        let liElement = document.createElement('li');

            let titleh4 = document.createElement('h4');
            titleh4.textContent = `Title: ${titleElement.value}`;

            let nameh4 = document.createElement('h4');
            nameh4.textContent = `Recipient Name: ${recipientNameElement.value}`;

            let spanElement = document.createElement('span');
            spanElement.textContent = messageElement.value;

            let buttonDiv = document.createElement('div');
            buttonDiv.setAttribute('id', "list-action");

            let sendButton = document.createElement('button');
            sendButton.setAttribute("type", "submit");
            sendButton.setAttribute("id", "send");
            sendButton.textContent = "Send";

            let deleteButton = document.createElement('button');
            deleteButton.setAttribute("type", "submit");
            deleteButton.setAttribute("id", "delete");
            deleteButton.textContent = "Delete";

            buttonDiv.appendChild(sendButton);
            buttonDiv.appendChild(deleteButton);

            liElement.appendChild(titleh4);
            liElement.appendChild(nameh4);
            liElement.appendChild(spanElement);
            liElement.appendChild(buttonDiv);

            ul.appendChild(liElement);
            listMailsDiv.appendChild(ul);

            sendButton.addEventListener('click', (e) => {
                e.preventDefault();
                ul.removeChild(liElement);
                let sentMailsDiv = document.querySelector('.sent-mails');
                let sentListUl = document.querySelector('.sent-list');
                let sentMailsLi = document.createElement('li');
                let toSpan = document.createElement('span');
                toSpan.textContent = `To: ${recipientNameElement.value}`;
                let titleSpan = document.createElement('span');
                titleSpan.textContent = `Title: ${titleElement.value}`;
                let deleteBtnDiv = document.createElement('div');
                deleteBtnDiv.classList.add('btn');
                let deleteButton2 = document.createElement('button');
                deleteButton2.setAttribute("type", "submit");
                deleteButton2.classList.add('delete');
                deleteButton2.textContent = "Delete";

                deleteBtnDiv.appendChild(deleteButton2);

                sentMailsLi.appendChild(toSpan);
                sentMailsLi.appendChild(titleSpan);
                sentMailsLi.appendChild(deleteBtnDiv)

                sentListUl.append(sentMailsLi);
                sentMailsDiv.appendChild(sentListUl);

                deleteButton2.addEventListener('click', (e) => {
                    e.preventDefault();
                    let trashLi = document.createElement('li');
                    let toSpan = document.createElement('span');
                    toSpan.textContent = `To: ${recipientNameElement.value}`;
                    let titleSpan = document.createElement('span');
                    titleSpan.textContent = `Title: ${titleElement.value}`;
                    trashLi.appendChild(toSpan);
                    trashLi.appendChild(titleSpan);
                    deleteListUl.appendChild(trashLi);
                    trashDiv.appendChild(deleteListUl);

                    sentMailsDiv.removeChild(sentListUl);
                })
            })

            deleteButton.addEventListener('click', (e) => {
                e.preventDefault();
                let trashLi = document.createElement('li');
                let toSpan = document.createElement('span');
                toSpan.textContent = `To: ${recipientNameElement.value}`;
                let titleSpan = document.createElement('span');
                titleSpan.textContent = `Title: ${titleElement.value}`;
                trashLi.appendChild(toSpan);
                trashLi.appendChild(titleSpan);
                deleteListUl.appendChild(trashLi);
                trashDiv.appendChild(deleteListUl);

                listMailsDiv.removeChild(ul);
            })
    })

    resetButton.addEventListener('click', (e) =>{
        e.preventDefault();
        recipientNameElement.value = '';
        titleElement.value = '';
        messageElement.value = '';
    })
}
solve()