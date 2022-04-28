function solve(word, text){
    word = word.toLocaleLowerCase();
    text = text.toLocaleLowerCase();

    text = text.split(' ');
    for (let worda of text) {
        if(worda == word){
            console.log(word);
            return;
        }
    }
    console.log(`${word} not found!`);
}

solve('javascript','JavaScript is the best programming language');