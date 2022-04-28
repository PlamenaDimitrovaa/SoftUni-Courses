function solve(text){
    text = text.split(' ');
    for (const word of text) {
        if(word.startsWith('#')){
            asciiCode = word.charCodeAt(1);
            let isLetter = (asciiCode >= 65 && asciiCode <= 90) || (asciiCode >= 97 && asciiCode <= 122);
            if(isLetter){
                console.log(word.slice(1));
            }
        }
    }
}

solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
solve('The symbol # is known #variously in English-speaking #regions as the #number sign');