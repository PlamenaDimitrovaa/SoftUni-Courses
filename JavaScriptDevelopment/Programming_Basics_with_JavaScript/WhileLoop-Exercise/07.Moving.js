function solve(input){
    let width = Number(input[0]);
    let length = Number(input[1]);
    let height = Number(input[2]);
    let index = 3;
    let freeSpace = width * length * height;
    let usedSpace = 0;
    while(true){
        if(input[index] === 'Done'){
            break;
        }

        if(usedSpace > freeSpace){
            break;
        }

        let space = Number(input[index]);
        usedSpace += space;
        index++;
    }

    if(freeSpace > usedSpace){
        console.log(`${freeSpace - usedSpace} Cubic meters left.`);
    }
    else{
        console.log(`No more free space! You need ${usedSpace - freeSpace} Cubic meters more.`);
    }
}