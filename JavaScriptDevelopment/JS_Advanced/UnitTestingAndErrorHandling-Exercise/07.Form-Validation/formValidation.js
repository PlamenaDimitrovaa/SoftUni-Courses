function validate() {
    let companyInputCheckboxElement = document.getElementById('company');
    companyInputCheckboxElement.addEventListener('change', (e) => {
        let companyInfoElement = document.getElementById('companyInfo');

        if (e.target.checked) {
            companyInfoElement.style.display = 'block'; 
        } else {
            companyInfoElement.style.display = 'none';
        }
    });

    let submitButtonElement = document.getElementById('submit');
    submitButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let values = [];

        const usernamePattern = /^[A-Za-z0-9]{3,20}$/;
        const passwordPattern = /^[A-Za-z0-9_]{5,15}$/;
        const emailPattern = /^[^@.]+@[^@]*\.[^@]*$/;

        let usernameInputElement = document.getElementById('username');
        if (!usernamePattern.test(usernameInputElement.value)) {
            usernameInputElement.style.borderColor = 'red';
            values.push(false);
        } else {
            usernameInputElement.style.borderColor = 'none';
            values.push(true);
        }

        let emailInputElement = document.getElementById('email');
        if (!emailPattern.test(emailInputElement.value)) {
            emailInputElement.style.borderColor = 'red';
            values.push(false);
        } else {
            emailInputElement.style.borderColor = 'none';
            values.push(true);
        }

        let passwordInputElement = document.getElementById('password');
        if (!passwordPattern.test(passwordInputElement.value)) {
            passwordInputElement.style.borderColor = 'red';
            values.push(false);
        } else {
            passwordInputElement.style.borderColor = 'none';
            values.push(true);
        }
    
        let confirmPasswordInputElement = document.getElementById('confirm-password');
        if (confirmPasswordInputElement.value !== passwordInputElement.value || !passwordPattern.test(confirmPasswordInputElement.value)) {
            confirmPasswordInputElement.style.borderColor = 'red';
            passwordInputElement.style.borderColor = 'red';
            values.push(false);
        } else {
            confirmPasswordInputElement.style.borderColor = 'none';
            passwordInputElement.style.borderColor = 'none';
            values.push(true);
        }

        let companyInfoElement = document.getElementById('company');
        if (companyInfoElement.checked) {
            let companyNumber = document.getElementById('companyNumber');

            if (companyNumber.value < 1000 || companyNumber.value > 9999) {
                companyNumber.style.borderColor = 'red';
                values.push(false);
            } else {
                companyNumber.style.borderColor = 'none';
                values.push(true);
            }
        }

        let validDivElement = document.getElementById('valid');
        if (values.includes(false)) {
            validDivElement.style.display = 'none';
        } else {
            validDivElement.style.display = 'block';
        }
    });
}