function calculate(input)
{
    let pensils = Number(input[0]);
    let markers = Number(input[1]);
    let littersDetergent = Number(input[2]);
    let discount = Number(input[3]);
    let sum = ((pensils * 5.80) + (markers * 7.20) + (littersDetergent * 1.20));
    let totalSum = sum - (sum * (discount / 100));
    console.log(totalSum);
}

calculate(["2 ","3 ","4 ","25 "]);
calculate(["4 ","2 ","5 ","13 "]);