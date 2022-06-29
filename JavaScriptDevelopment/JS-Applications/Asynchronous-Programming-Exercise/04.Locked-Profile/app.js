async function lockedProfile() {
    const url = `http://localhost:3030/jsonstore/advanced/profiles`;
    const result = await fetch(url);
    const data = await result.json();

    const main = document.getElementById('main');
    main.innerHTML = '';
    let counter = 0;

    let keys = Object.keys(data);
    keys.forEach(key => {
        const profileDiv = document.createElement('div');
        profileDiv.classList.add('profile');

        const img = document.createElement('img');
        img.classList.add('userIcon');
        img.src = "./iconProfile2.png";

        const lockLabel = document.createElement('label');
        lockLabel.textContent = 'Lock';

        const inputRadioElementLocked = document.createElement('input');
        inputRadioElementLocked.setAttribute('type', 'radio');
        inputRadioElementLocked.setAttribute('name', `user${counter}Locked`);
        inputRadioElementLocked.setAttribute('value', 'unlock');
        inputRadioElementLocked.checked = true;

        const unlockLabel = document.createElement('label');
        unlockLabel.textContent = 'Unlock';

        const inputRadioElementUnlocked = document.createElement('input');
        inputRadioElementUnlocked.setAttribute('type', 'radio');
        inputRadioElementUnlocked.setAttribute('name', `user${counter}Locked`);
        inputRadioElementUnlocked.setAttribute('value', 'unlock');
        inputRadioElementUnlocked.checked = false;

        const brElement = document.createElement('BR');
        const hr = document.createElement('HR');

        const usernameLabel = document.createElement('label');
        usernameLabel.textContent = 'Username';
        
        const usernameInput = document.createElement('input');
        usernameInput.setAttribute('type', 'text');
        usernameInput.setAttribute('name', `user${counter}Locked`);
        usernameInput.setAttribute('value', ``);
        usernameInput.disabled = false;
        usernameInput.readOnly = true;
        usernameInput.value = `${data[key].username}`;

        const hiddenDiv = document.createElement('div');
        hiddenDiv.classList.add('hiddenInfo');

        const emailLabel = document.createElement('label');
        emailLabel.textContent = 'Email:';
        
        const inputEmail = document.createElement('input');
        inputEmail.setAttribute('type', 'email');
        inputEmail.setAttribute('name', `user${counter}Email`);
        inputEmail.setAttribute('value', '');
        inputEmail.disabled = true;
        inputEmail.readOnly = true;
        inputEmail.value = data[key].email;

        const ageLabel = document.createElement('label');
        ageLabel.textContent = 'Email:';
        
        const inputAge = document.createElement('input');
        inputAge.setAttribute('type', 'email');
        inputAge.setAttribute('name', `user${counter}Age`);
        inputAge.setAttribute('value', '');
        inputAge.disabled = true;
        inputAge.readOnly = true;
        inputAge.value = data[key].age;

        const showMoreButton = document.createElement('button');
        showMoreButton.textContent = 'Show more';
        showMoreButton.addEventListener('click', (e) => {
            if (inputRadioElementUnlocked.checked == true) {
                if (e.target.textContent === 'Show more') {
                    hiddenDiv.classList.remove('hiddenInfo');
                    showMoreButton.textContent = 'Hide it';
                } else {
                    hiddenDiv.classList.add('hiddenInfo');
                    showMoreButton.textContent = 'Show more';
                }
            }
        })

        hiddenDiv.appendChild(hr);
        hiddenDiv.appendChild(emailLabel);
        hiddenDiv.appendChild(inputEmail);
        hiddenDiv.appendChild(ageLabel);
        hiddenDiv.appendChild(inputAge);

        profileDiv.appendChild(img);
        profileDiv.appendChild(lockLabel);
        profileDiv.appendChild(inputRadioElementLocked);
        profileDiv.appendChild(unlockLabel);
        profileDiv.appendChild(inputRadioElementUnlocked);
        profileDiv.appendChild(brElement);
        profileDiv.appendChild(hr);
        profileDiv.appendChild(usernameLabel);
        profileDiv.appendChild(usernameInput);
        profileDiv.appendChild(hiddenDiv);
        profileDiv.appendChild(showMoreButton);

        main.appendChild(profileDiv);

        counter++;
    })
}