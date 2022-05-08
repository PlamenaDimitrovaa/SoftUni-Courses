function solve(counter){

    function add(a,b){
        return a + b;
    }

    return add.bind(this, counter);
}

let add5 = solve(5);
console.log(add5(2));
console.log(add5(3));