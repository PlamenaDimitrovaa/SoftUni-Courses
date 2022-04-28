function calculate(input)
{
    let nylon = Number(input[0]);
    let paint = Number(input[1]);
    let thinner = Number(input[2]);
    let hours = Number(input[3]);
    let nylonSum = (nylon + 2) * 1.50;
    let paintSum = (paint + (paint * 0.1)) * 14.50;
    let thinnerSum = thinner * 5.00;
    let sum = nylonSum + paintSum + thinnerSum + 0.40;
    let sumForWorkers = (sum * 0.3) * hours;
    let finalSum = sum + sumForWorkers;
    console.log(finalSum);
}

calculate(["10 ","11 ","4 ","8 "]);