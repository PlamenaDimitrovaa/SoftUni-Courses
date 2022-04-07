function tennisRanklist(input){
    let index = 0;
    let numberOfTournaments = Number(input[index]);
    index++;
    let startPoints = Number(input[index]);
    let numberOfWonTournaments = 0;
    index++;
    let tempPoints = 0;
    for(let i = 0; i < numberOfTournaments; i++){
        let score = input[index];
        index++;

        switch(score){
            case 'W':
                tempPoints += 2000;
                numberOfWonTournaments++;
                break;
            case 'F': tempPoints += 1200; break;
            case 'SF': tempPoints += 720; break;
        }
    }
       
    console.log(`Final points: ${tempPoints + startPoints}`);
    console.log(`Average points: ${Math.floor(tempPoints / numberOfTournaments)}`);
    console.log(`${(numberOfWonTournaments / numberOfTournaments * 100).toFixed(2)}%`);
}