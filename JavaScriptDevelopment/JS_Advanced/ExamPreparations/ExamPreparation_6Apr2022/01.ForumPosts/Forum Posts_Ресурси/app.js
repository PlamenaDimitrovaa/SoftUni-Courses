window.addEventListener("load", solve);

function solve(){
  const input = {
    title: document.getElementById("post-title"),
    category: document.getElementById("post-category"),
    content: document.getElementById("post-content"),
  };
  const lists = {
    review: document.getElementById("review-list"),
    published: document.getElementById('published-list'),
  };
  document.getElementById("publish-btn").addEventListener('click', publish);
  document.getElementById("clear-btn").addEventListener('click', clear);

  function publish(e){
    e.preventDefault();

    const title = input.title.value;
    const category = input.category.value;
    const content = input.content.value;

    if(title == '' || category == '' || content == ''){
      return;
    }

    let li = document.createElement('li');
    li.className = 'rpost';
    li.innerHTML = `<article>
        <h4>${title}</h4>
        <p>Category: ${category}</p>
        <p>Content: ${content}</p>
    </article>
    <button class = 'action-btn edit'>Edit</button>
    <button class = 'action-btn approve'>Approve</button>`;

    const editBtn = li.querySelector('.edit');
    const approveBtn = li.querySelector('.approve');
    editBtn.addEventListener('click', edit);
    approveBtn.addEventListener('click', approve);

    lists.review.appendChild(li);

    input.title.value = '';
    input.category.value = '';
    input.content.value = '';

    function edit(){
      input.title.value = title;
      input.category.value = category;
      input.content.value = content;

      li.remove();
    }

    function approve(){
      lists.published.appendChild(li);
      editBtn.remove();
      approveBtn.remove();
    }
  }

  function clear(){
    lists.published.innerHTML = '';
  }
}

// function solve() {
//   let titleElement = document.getElementById("post-title");
//   let categoryElement = document.getElementById("post-category");
//   let contentElement = document.getElementById("post-content");
//   let publishBtn = document.getElementById("publish-btn");
//   let reviewListUl = document.getElementById("review-list");
  
  
//   publishBtn.addEventListener('click', publish);
  
//   function publish(e){
//     e.preventDefault();
//     if(titleElement.value !== '' && categoryElement.value !== '' && contentElement.value !== ''){

//       let title = titleElement.value;
//       let category = categoryElement.value;
//       let content = contentElement.value;
      
//       let rpostLi = document.createElement('li');
//       rpostLi.className = 'rpost';
//       let article = document.createElement('article');
//       let h4 = document.createElement('h4');
//       h4.textContent = `${titleElement.value}`;
//       let categoryp = document.createElement('p');
//       categoryp.textContent = `Category: ${categoryElement.value}`;
//       let contentp = document.createElement('p');
//       contentp.textContent = `Content: ${contentElement.value}`;
      
//       article.appendChild(h4);
//       article.appendChild(categoryp);
//       article.appendChild(contentp);
      
//       let editBtn = document.createElement('button');
//       editBtn.textContent = 'Edit';
//       editBtn.className = 'action-btn edit';

//       editBtn.addEventListener('click', edit);

//       let approveBtn = document.createElement('button');
//       approveBtn.textContent = 'Approve';
//       approveBtn.className = 'action-btn approve';

//       approveBtn.addEventListener('click', approve);

//       rpostLi.appendChild(article);
//       rpostLi.appendChild(approveBtn);
//       rpostLi.appendChild(editBtn);
      
//       reviewListUl.appendChild(rpostLi);
      
//       titleElement.value = '';
//       categoryElement.value = '';
//       contentElement.value = '';

      
//       function edit(e){
//         e.preventDefault();
        
//           titleElement.value = title;
//           categoryElement.value = category;
//           contentElement.value = content;
//           rpostLi.remove();
//           reviewListUl.appendChild(rpostLi);
//         }
        
        
//         let ul = document.getElementById('published-list'); 
//         function approve(){
//           ul.appendChild(rpostLi);
//           editBtn.remove();
//           approveBtn.remove();
//         }

//         let clearBtn = document.getElementById("clear-btn");
//         clearBtn.addEventListener('click', clear);

//         function clear(){
//           ul.innerHTML = '';
//         }
//     }
//   }
// }
