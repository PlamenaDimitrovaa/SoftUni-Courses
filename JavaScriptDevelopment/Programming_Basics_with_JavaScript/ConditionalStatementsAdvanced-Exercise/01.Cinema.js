function calculate(input)
{
    let type = input[0];
    let rows = Number(input[1]);
    let cols = Number(input[2]);

    let places = rows * cols;
    let income = 0;
    if(type === 'Premiere')
    {
        income = places * 12.00;
    }
    else if(type === 'Normal')
    {
        income = places * 7.50;
    }
    else if(type === 'Discount')
    {
        income = places * 5.00;
    }

    console.log(income.toFixed(2));

}