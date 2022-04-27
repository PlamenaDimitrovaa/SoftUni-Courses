// function camelPad(str){
//    str = str.replace(/([A-Z]+)([A-Z][a-z])/g, ' $1 $2').replace(/([a-z\d])([A-Z])/g, '$1 $2').replace(/([a-zA-Z])(\d)/g, '$1 $2').replace(/^./, function(str){ return str.toUpperCase(); }).trim();
//    let array = str.split(' ');
//     console.log(array.join(', '));
// }

// camelPad('SplitMeIfYouCanHaHaYouCantOrYouCan');

function solve(text){
    let words = [];
    let currWord = text[0];
    for(let i = 1; i < text.length; i++){
        if(text[i].toUpperCase() !== text[i]){
            currWord = currWord.concat(text[i]);
        }
        else{
            words.push(currWord);
            currWord = text[i];
        }
    }

    words.push(currWord);
    console.log(words.join(', '));
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan')