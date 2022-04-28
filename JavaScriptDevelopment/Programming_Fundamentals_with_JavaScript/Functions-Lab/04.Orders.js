function solve(product, quantity){
    if(product === 'coffee'){
        return Number((quantity * 1.50)).toFixed(2);
    }
    else if(product === 'water'){
       return Number((quantity * 1.00)).toFixed(2);
    }
    else if(product === 'coke'){
        return Number((quantity * 1.40)).toFixed(2);
    }
    else if(product === 'snacks'){
       return Number((quantity * 2.00)).toFixed(2);
    }
}

solve('water', 5);
