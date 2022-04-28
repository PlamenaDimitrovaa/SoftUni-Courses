function solve(input){
    let index = 0;
    let book = input[index];
    let isFound = false;
    index++;
    let count = -1;
    while(true){
        count++;
        let currentBook = input[index];
        if(currentBook === 'No More Books'){
            break;
        }
        if(currentBook === book){
            isFound = true;
            break;
        }
        index++;
    }

    if(isFound){
        console.log(`You checked ${count} books and found it.`);
    }
    else{
        console.log("The book you search is not here!");
        console.log(`You checked ${count} books.`);
    }
}

solve(["Troy",
"Stronger",
"Life Style",
"Troy"]);

solve(["The Spot",
"Hunger Games",
"Harry Potter",
"Torronto",
"Spotify",
"No More Books"]);