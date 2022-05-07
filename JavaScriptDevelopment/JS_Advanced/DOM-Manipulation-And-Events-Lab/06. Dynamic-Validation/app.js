function validate() {
    let inputElement = document.getElementById('email');
    let pattern = /^([\w\-.]+)@([a-z]+)(\.[a-z]+)+$/;
    inputElement.addEventListener('change', (e) => {
        if (pattern.test(inputElement.value)) {
            e.currentTarget.classList.remove('error');
        } else {
            e.currentTarget.classList.add('error');
        }
    });
}