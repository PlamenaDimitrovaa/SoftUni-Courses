function calculate(input)
{
    let recordInSeconds = Number(input[0]);
    let distanceInMeters = Number(input[1]);
    let timeInSecForOneMeter = Number(input[2]);
    let time = distanceInMeters * timeInSecForOneMeter;
    let toAugment = Math.floor(distanceInMeters / 15) * 12.5;
    time = time + toAugment;
    if(time < recordInSeconds)
    {
        console.log(`Yes, he succeeded! The new world record is ${(time).toFixed(2)} seconds.`);
    }
    else
    {
        console.log(`No, he failed! He was ${Math.abs((recordInSeconds - time)).toFixed(2)} seconds slower.`);
    }
}

calculate((['10464',
    '1500',
    '20']));

calculate(['55555.67', '3017', '5.03']);