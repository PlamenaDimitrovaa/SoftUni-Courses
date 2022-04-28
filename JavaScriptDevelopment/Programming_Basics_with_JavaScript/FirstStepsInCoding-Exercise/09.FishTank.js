function calculate(input)
{
    let length = Number(input[0]);
    let width = Number(input[1]);
    let height = Number(input[2]);
    let percentage = Number(input[3]);
    let volume = length * width * height;
    let volumeInLitters = volume / 1000;
    let occupiedSpace = percentage / 100;
    let neededLitters = volumeInLitters * (1 - occupiedSpace);
    console.log(neededLitters);
}

calculate(['85', '75', '47', '17']);