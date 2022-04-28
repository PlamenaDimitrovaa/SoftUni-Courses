function calculate(input){
    let index = 0;
    let actorName = input[index];
    index++;
    let points = Number(input[index]);
    index++;
    let juryCount = Number(input[index]);
    index++;

    for(let i = 0; i < juryCount; i++){
        let name = input[index];
        index++;
        let tempPoints = Number(input[index]);
        index++;

        points += name.length * tempPoints / 2;

        if(points > 1250.5){
            break;
        }
    }

    if(points > 1250.5){
        console.log(`Congratulations, ${actorName} got a nominee for leading role with ${points.toFixed(1)}!`)
    } else{
        console.log(`Sorry, ${actorName} you need ${(1250.5 - points).toFixed(1)} more!`)
    }
}