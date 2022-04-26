function solve(text, word){
    let count = 0;
    let words = text.split(' ');
    for (const worda of words) {
        if(worda === word){
            count++;
        }
    }

    console.log(count);
}

solve('This is a word and it also is a sentence','is');