window.addEventListener('load', solve);
function solve(){
    let productTypeElement = document.getElementById('type-product');
    let descriptionElement = document.getElementById('description');
    let nameElement = document.getElementById('client-name');
    let phoneElement = document.getElementById('client-phone');
    let divWithButton = document.getElementById("right");
    let sendButton = divWithButton.querySelector('button');
    
    sendButton.addEventListener('click', (e) => {
        e.preventDefault();
        let product = productTypeElement.value;
        let description = descriptionElement.value;
        let name = nameElement.value;
        let phone = phoneElement.value;

        if(productTypeElement.value == 'Computer' || productTypeElement.value == 'Phone' 
            && descriptionElement.value !== '' && nameElement.value !== '' && phoneElement.value !== ''){

                let section = document.getElementById('received-orders');
        
                let containerDiv = document.createElement('div');
                containerDiv.className = 'container';
                let productH = document.createElement('h2');
                productH.textContent = `Product type for repair: ${product}`;
                let infoH = document.createElement('h3');
                infoH.textContent = `Client information: ${name}, ${phone}`;
                let descriptionH = document.createElement('h4');
                descriptionH.textContent = `Description of the problem: ${description}`;
                let startBtn = document.createElement('button');
                startBtn.className = 'start-btn';
                startBtn.textContent = 'Start repair';
                let finishBtn = document.createElement('button');
                finishBtn.className = 'finish-btn';
                finishBtn.textContent = 'Finish repair';
                
                containerDiv.appendChild(productH);
                containerDiv.appendChild(infoH);
                containerDiv.appendChild(descriptionH);
                containerDiv.appendChild(startBtn);
                containerDiv.appendChild(finishBtn);
                
                section.appendChild(containerDiv);
                
                finishBtn.disabled = true;

                productTypeElement.value = '';
                descriptionElement.value = '';
                nameElement.value = '';
                phoneElement.value = '';

                startBtn.addEventListener('click', (e) => {
                    e.preventDefault();
                    startBtn.disabled = true;
                    finishBtn.disabled = false;
                })

                finishBtn.addEventListener('click', (e) => {
                    e.preventDefault();
                    let completedOrdersSection = document.getElementById('completed-orders');
                    containerDiv.removeChild(startBtn);
                    containerDiv.removeChild(finishBtn);
                    completedOrdersSection.appendChild(containerDiv);
                })

                let clearbtn = document.querySelector('.clear-btn');
                clearbtn.addEventListener('click', (e) => {
                    e.preventDefault();
                    containerDiv.remove();
                })
            }
    })
}

// function solve() {
//     let productTypeElement = document.getElementById("type-product");
//     let descriptionElement = document.getElementById("description");
//     let clientNameElement = document.getElementById("client-name");
//     let clientPhoneElement = document.getElementById("client-phone");
//     let divWithButton = document.getElementById("right");
//     let sendButton = divWithButton.querySelector('button');

//     sendButton.addEventListener('click', (e) => {
//         e.preventDefault();
//         let product = productTypeElement.value;
//         let description = descriptionElement.value;
//         let clientName = clientNameElement.value;
//         let clientPhone = clientPhoneElement.value;


//         if(productTypeElement.value == 'Computer' || productTypeElement.value == 'Phone' 
//         && descriptionElement.value !== '' && clientNameElement.value !== '' && clientPhoneElement.value !== ''){
            
//             let receivedOrdersSection = document.getElementById('received-orders');
            
//             let containerDiv = document.createElement('div');
//             containerDiv.className = 'container';
//             let productTypeh2 = document.createElement('h2');
//             productTypeh2.textContent = `Product type for repair: ${product}`;
//             let clientInfoh3 = document.createElement('h3');
//             clientInfoh3.textContent = `Client information: ${clientName}, ${clientPhone}`;
//             let descriptionh4 = document.createElement('h4');
//             descriptionh4.textContent = `Description of the problem: ${description}`;
//             let startBtn = document.createElement('button');
//             startBtn.className = "start-btn";
//             startBtn.textContent = "Start repair";

//             descriptionElement.value = '';
//             clientNameElement.value = '';
//             clientPhoneElement.value = '';
            
//             let finishBtn = document.createElement('button');
//             finishBtn.className = "finish-btn";
//             finishBtn.textContent = "Finish repair";
//             finishBtn.disabled = true;
            
//             containerDiv.appendChild(productTypeh2);
//             containerDiv.appendChild(clientInfoh3);
//             containerDiv.appendChild(descriptionh4);
//             containerDiv.appendChild(startBtn);
//             containerDiv.appendChild(finishBtn);
            
//             receivedOrdersSection.appendChild(containerDiv);
//             startBtn.addEventListener('click', (e) => {
//                 e.target.disabled = true;
//                 finishBtn.disabled = false;
//                 })

//                 finishBtn.addEventListener('click', () => {
//                     let completedOrdersSection2 = document.getElementById('completed-orders');
//                     let containerDiv2 = document.createElement('div');
//                     containerDiv2.className = 'container';
//                     let productTypeh22 = document.createElement('h2');
//                     productTypeh22.textContent = `Product type for repair: ${product}`;
//                     let clientInfoh33 = document.createElement('h3');
//                     clientInfoh33.textContent = `Client information: ${clientName}, ${clientPhone}`;
//                     let descriptionh44 = document.createElement('h4');
//                     descriptionh44.textContent = `Description of the problem: ${description}`;
                    
//                     containerDiv2.appendChild(productTypeh22);
//                     containerDiv2.appendChild(clientInfoh33);
//                     containerDiv2.appendChild(descriptionh44);
                    
//                     completedOrdersSection2.appendChild(containerDiv2);

//                     containerDiv.remove();

//                     let clearBtn = document.querySelector('.clear-btn');
//                     clearBtn.addEventListener('click', () => {
//                         containerDiv2.remove();
//                     })
//                 })
//             }
//         })
// }