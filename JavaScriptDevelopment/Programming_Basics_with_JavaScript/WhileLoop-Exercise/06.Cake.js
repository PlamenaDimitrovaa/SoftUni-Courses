function solve(input){
    let length = Number(input[0]);
    let width = Number(input[1]);
    let index = 2;
    let numberOfPieces = length * width;
    let numberOfUsedPieces = 0;
    while(true){
        if(input[index] === 'STOP')
        {
            break;
        }
        
        if(numberOfUsedPieces >= numberOfPieces)
        {
            break;
        }

        let currPieces = Number(input[index]);
        numberOfUsedPieces += currPieces;
        index++;
    }

    if(numberOfPieces >= numberOfUsedPieces){
        console.log(`${(numberOfPieces - numberOfUsedPieces)} pieces are left.`);
    }
    else{
        console.log(`No more cake left! You need ${numberOfUsedPieces - numberOfPieces} pieces more.`);
    }
}