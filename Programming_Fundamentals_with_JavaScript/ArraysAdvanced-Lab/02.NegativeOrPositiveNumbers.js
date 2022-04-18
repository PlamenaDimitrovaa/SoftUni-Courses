function solve(input){
    let result = [];
    for(let element of input){
        element = Number(element);
        if(element < 0){
            result.unshift(element);
        }
        else{
            result.push(element);
        }
    }

    for(let element of result){
        console.log(element);
    }
}