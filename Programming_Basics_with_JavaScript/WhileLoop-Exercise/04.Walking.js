function solve(input){
    let index = 0;
    let totalSteps = 0;

    while(totalSteps < 10000){
        if(input[index] === 'Going home')
        {
            index++;
            currSteps = Number(input[index]);
            totalSteps += currSteps;
            break;
        }

        currSteps = Number(input[index]);
        totalSteps += currSteps;
        index++;
    }

    if(totalSteps >= 10000){
        console.log(`Goal reached! Good job!`);
        console.log(`${totalSteps - 10000} steps over the goal!`);
    }
    else{
        console.log(`${10000 - totalSteps} more steps to reach goal.`);
    }
}

solve(["1000",
"1500",
"2000",
"6500"]);
