function calculate(input)
{
    let name = input[0];
    let episodeDurance = Number(input[1]);
    let breakDurance = Number(input[2]);
    let timeForLunch = breakDurance * 0.125;
    let timeForRest = breakDurance * 0.25;
    let timeLeft = breakDurance - (timeForLunch + timeForRest);
    if(timeLeft >= episodeDurance)
    {
        console.log(`You have enough time to watch ${name} and left with ${Math.ceil(timeLeft - episodeDurance)} minutes free time.`);
    }
    else
    {
        console.log(`You don't have enough time to watch ${name}, you need ${Math.ceil(episodeDurance - timeLeft)} more minutes.`);
    }
}

calculate(['Game of Thrones', '60', '96']);
calculate(['Teen Wolf', '48', '60']);
