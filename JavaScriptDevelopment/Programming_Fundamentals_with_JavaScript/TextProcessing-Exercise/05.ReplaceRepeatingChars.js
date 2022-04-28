function solve(input){
   let unique = "";
   for(let i = 0; i < input.length; i++){
       let currentChar = input.charAt(i);
       let nextChar = input.charAt(i + 1);
       if(currentChar !== nextChar){
           unique += currentChar;
       }
   }

   console.log(unique);
}

solve('aaaaabbbbbcdddeeeedssaa');