function solve(input){
    let words = input.split(' ');
    let result = {};
    let array = [];
    
    for (let word of words) {
        word = word.toLocaleLowerCase();
        if(result.hasOwnProperty(word)){
            result[word]++;
        }
        else{
            result[word] = 1;
        }
    }

    let sorted = Object.entries(result);
    sorted.sort((a, b) => b[1] - a[1]);

    for(let [word, count] of sorted){
        if(count % 2 !== 0){
            array.push(word);
        }
    }

   console.log(array.join(' '));
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');