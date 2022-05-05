function subtract() {
    let firstNumber = Number(document.getElementById('firstNumber').value);
    let secondNumber = Number(document.getElementById('secondNumber').value);
    let result = firstNumber - secondNumber;
    let toDo = document.getElementById('result');

    toDo.textContent = result;

    console.log(result);
}