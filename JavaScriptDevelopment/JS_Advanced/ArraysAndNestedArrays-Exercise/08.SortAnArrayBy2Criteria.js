function solve(input){
    let sortedByLength = input.sort((a, b) => a.length - b.length || a.localeCompare(b));
    sortedByLength.forEach(a => console.log(a));
}

solve(['alpha', 
'beta', 
'gamma']
);

solve(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']
);

solve(['test', 
'Deny', 
'omen', 
'Default']
);