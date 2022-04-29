function solve(number){
  let isTrue = true;
  let numberAsString = number.toString();
  let sum = 0;
  sum += Number(numberAsString[0]);

  for(let i = 1; i < numberAsString.length; i++){
      sum += Number(numberAsString[i]);

      if(numberAsString[i] !== numberAsString[i - 1]){
          isTrue = false;
      }
  }
    console.log(isTrue);
    console.log(sum);
}

solve(2222222);
solve(1234);