function days(input)
{
    let numOfDay = Number(input[0]);
    if(numOfDay == 1)
    {
        console.log('Monday');
    }
    else if(numOfDay == 2)
    {
        console.log('Tuesday');
    }
    else if(numOfDay == 3)
    {
        console.log('Wednesday');
    }
    else if(numOfDay == 4)
    {
        console.log('Thursday');
    }
    else if(numOfDay == 5)
    {
        console.log('Friday');
    }
    else if(numOfDay == 6)
    {
        console.log('Saturday');
    }
    else if(numOfDay == 7)
    {
        console.log('Sunday');       
    }
    else
    {
        console.log('Error');
    }
}