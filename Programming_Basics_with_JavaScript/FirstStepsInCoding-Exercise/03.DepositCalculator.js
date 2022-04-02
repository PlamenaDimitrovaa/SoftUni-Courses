function getSum(input)
{
    let depositSum = Number(input[0]);
    let months = Number(input[1]);
    let annualInterestRate = Number(input[2]);
    annualInterestRate = annualInterestRate / 100;
    let totalSum = depositSum + months * ((depositSum * annualInterestRate) / 12);
    console.log(totalSum);
}

getSum(["200","3","5.7"]);
getSum(["2350","6 ","7 "]);