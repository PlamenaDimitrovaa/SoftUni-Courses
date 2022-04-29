function solve(input){
    let regex = /(\w+)/g;

    let words = input.match(regex);
    let result = [];

    for (const word of words) {
        let wordToUpper = word.toUpperCase();
        result.push(wordToUpper);
    }

    console.log(result.join(', '));
}