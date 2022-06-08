function solve(){

   let createButton = document.querySelector('.site-content aside button.btn.create');
   createButton.addEventListener('click', createArticleHandler);

   function createArticleHandler(e){
      e.preventDefault();

      let authorInput = document.querySelector('#creator');
      let titleInput = document.querySelector('#title');
      let categoryInput = document.querySelector('#category');
      let contentTextarea = document.querySelector('#content');

      let articleElement = document.createElement('article');

      let titleHeading = document.createElement('h1');
      titleHeading.textContent = titleInput.value;

      let categoryPara = document.createElement('p');
      categoryPara.textContent = 'Category:';
      let categoryStrong = document.createElement('strong');
      categoryStrong.textContent = categoryInput.value;
      categoryPara.appendChild(categoryStrong);

      let creatorPara = document.createElement('p');
      creatorPara.textContent = 'Creator:';
      let creatorStrong = document.createElement('strong');
      creatorStrong.textContent = authorInput.value;
      creatorPara.appendChild(creatorStrong);

      let contentPara = document.createElement('p');
      contentPara.textContent = contentTextarea.value;

      let buttonsDiv = document.createElement('div');
      buttonsDiv.classList.add('buttons');

      let deleteButton = document.createElement('button');
      deleteButton.textContent = "Delete";
      deleteButton.classList.add('btn', 'delete');
      deleteButton.addEventListener('click', deleteArticleHandler);

      let archiveButton = document.createElement('button');
      archiveButton.textContent = "Archive";
      archiveButton.classList.add('btn', 'archive');
      archiveButton.addEventListener('click', archiveArticleHandler);

      buttonsDiv.appendChild(deleteButton);
      buttonsDiv.appendChild(archiveButton);

      articleElement.appendChild(titleHeading);
      articleElement.appendChild(categoryPara);
      articleElement.appendChild(creatorPara);
      articleElement.appendChild(contentPara);
      articleElement.appendChild(buttonsDiv);

      let postsSection = document.querySelector('.site-content main section');
      postsSection.appendChild(articleElement);

   }

   function deleteArticleHandler(e){
      let deleteButton = e.target;
      let articleToDelete = deleteButton.parentElement.parentElement;
      articleToDelete.remove();
   }

   function archiveArticleHandler(e){
      let articleToArchive = e.target.parentElement.parentElement;
      let archiveOl = document.querySelector('.archive-section ol');

      let archiveLis = Array.from(archiveOl.querySelectorAll('li'));
      let articleTitleHeading = articleToArchive.querySelector('h1');
      let articleTitle = articleTitleHeading.textContent;

      let newTitleLi = document.createElement('li');
      newTitleLi.textContent = articleTitle;

      articleToArchive.remove();

      archiveLis.push(newTitleLi);
      archiveLis
       .sort((a,b) => a.textContent.localeCompare(b.textContent))
       .forEach(li => archiveOl.appendChild(li))
   }
  }
