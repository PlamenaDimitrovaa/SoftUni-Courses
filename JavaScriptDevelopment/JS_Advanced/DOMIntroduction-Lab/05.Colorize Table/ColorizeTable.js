// function colorize() {
//     let rowElements = document.querySelectorAll('tr:nth-of-type(2n) td')
//     rowElements.forEach(x => x.style.backgroungColor = 'teal');
// }

function colorize(){
    let rowElements = document.getElementsByTagName('tr');
    let rowElementsArr = Array.from(rowElements);
    rowElementsArr.forEach((x, i) => {
        if(i % 2 !== 0){
            x.style.backgroundColor = 'teal';
        }
    });
}