function bonusScore(input)
{
    let score = Number(input[0]);
    let bonusPoints = 0;
    if(score <= 100)
    {
        bonusPoints += 5;
    }
    else if(score > 100 && score <= 1000)
    {
        bonusPoints += (score * 0.2);
    }
    else if(score > 1000)
    {
        bonusPoints += (score * 0.1);
    }

    if(score % 2 == 0)
    {
        bonusPoints += 1;
    }

    let lastDigit = score % 10;
    if(lastDigit == 5)
    {
        bonusPoints += 2;
    }

    console.log(bonusPoints);
    console.log(score + bonusPoints);
}