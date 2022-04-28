function calculate(input)
{
    let pages = Number(input[0]);
    let pagesForOneHour = Number(input[1]);
    let days = Number(input[2]);
    let totalTime = pages / pagesForOneHour;
    let timePerDay = totalTime / days;
    console.log(timePerDay);
}

calculate(["212 ","20 ","2 "]);
calculate(["432 ","15 ","4 "]);