function solve(array){
    array.sort(twoCriteriaSort);
    
    function twoCriteriaSort(cur, next) {
        if (cur.length === next.length) {
          return cur.localeCompare(next);
        }
        return cur.length - next.length;
      }

   for(let element of array){
       console.log(`${element}` + " ");
   }
}

solve(['alpha', 'beta', 'gamma']);
solve(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);