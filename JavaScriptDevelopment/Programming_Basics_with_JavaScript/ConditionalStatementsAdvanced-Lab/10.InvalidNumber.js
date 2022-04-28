function check(input)
{
    let number = Number(input[0]);
    if(number !== 0 )
    {
        if(number < 100 || number > 200)
        {
            console.log('invalid');
        }
    }
}