function solve(input){
    let num = Number(input[0]);
    let counter = 1;

    while(counter <= num){
        console.log(counter);
        counter = (counter * 2) + 1;
    }
}