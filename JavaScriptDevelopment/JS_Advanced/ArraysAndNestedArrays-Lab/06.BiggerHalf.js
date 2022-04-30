function solve(input){
    input.sort((a,b) => a - b);
    // console.log(input);
    let newArr = [];
    if(input.length % 2 === 0){
        newArr = input.slice(-(input.length /2));
    }else{
        newArr = input.slice(-((input.length /2) + 1));
    }

    return newArr;
}

solve([4,7,2,5]);
solve([3, 19, 14, 7, 2, 19, 6]);