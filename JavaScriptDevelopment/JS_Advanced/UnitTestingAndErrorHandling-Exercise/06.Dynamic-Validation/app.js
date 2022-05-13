function validate() {
    const emailPattern = /^[a-z0-9_\-]+@[a-z0-9_\-]+.[a-z0-9_\-]+$/;
    let input = document.getElementById('email');
    input.addEventListener('change', () => {
        let email = input.value;
        if(!(emailPattern.test(email))){
            input.classList.add('error');
        } else{
            input.classList.remove('error');
        }
    });
}