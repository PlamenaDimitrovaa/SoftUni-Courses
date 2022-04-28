function solve(input){
    let gradesToReach = Number(input[0]);
    let index = 1;
    let averageScore = 0;
    let numberOfProblems = 0;
    let currentName = "";
    let count = 0;
    while(true){

        if(input[index] === 'Enough'){
            break;
        }

        currentName = input[index];
        numberOfProblems++;
        index++;

        let grade = Number(input[index]);

        if(grade <= 4){
            count++;
        }

        if(count >= gradesToReach){
            console.log(`You need a break, ${count} poor grades.`);
            return;
        }
        
        averageScore += grade;
        index++;
    }

    console.log(`Average score: ${(averageScore / numberOfProblems).toFixed(2)}`);
    console.log(` Number of problems: ${numberOfProblems}`);
    console.log(`Last problem: ${currentName}`);
}