function solve(one, two, three){

    let maxNum;

    if(one > two && one > three){
        maxNum = one;
    } else if(two > one && two > three){
        maxNum = two;
    } else{
        maxNum = three;
    }

    console.log(`The largest number is ${maxNum}.`);
}
