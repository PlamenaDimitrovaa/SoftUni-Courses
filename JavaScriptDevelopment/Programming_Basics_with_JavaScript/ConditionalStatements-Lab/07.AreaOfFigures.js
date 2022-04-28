function area(input)
{
    let type = input[0];
    if(type == "square")
    {
        let length = Number(input[1]);
        let result = length * length;
        console.log(result.toFixed(3));
    }
    else if(type == "rectangle")
    {
        let length1 = Number(input[1]);
        let length2 = Number(input[2]);
        let result = length1 * length2;
        console.log(result.toFixed(3));
    }
    else if(type == "circle")
    {
        let radius = Number(input[1]);
        let result = Math.PI * (radius * radius);
        console.log(result.toFixed(3));
    }
    else if(type == "triangle")
    {
        let length = Number(input[1]);
        let height = Number(input[2]);
        let result = (length * height) / 2;
        console.log(result.toFixed(3));
    }
}