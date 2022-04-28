function grade(input)
{
    let firstNum = Number(input[0]);
    let secondNum = Number(input[1]);
    if(firstNum > secondNum)
    {
        console.log(firstNum);
    }
    else
    {
        console.log(secondNum);
    }
}

grade(["3", "5"]);