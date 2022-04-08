function vacation(input){
    let moneyForExcursion = Number(input[0]);
    let currMoney = Number(input[1]);
    let indexOfAction = 2;
    let indexOfMoney = 3;

    let countOfDaysSpending = 0;
    let countOfAllDays = 0;

    while(currMoney < moneyForExcursion){
        countOfAllDays++;
        let action = input[indexOfAction];
        let money = Number(input[indexOfMoney]);

        if(action === "spend"){
            countOfDaysSpending++;

            if(countOfDaysSpending === 5){
                break;
            }

            if(currMoney - money < 0){
                currMoney = 0;
            } else{
                currMoney -= money;
            }
        } else if(action === "save"){
            currMoney += money;
            countOfDaysSpending = 0;
        }

        indexOfAction += 2;
        indexOfMoney += 2;
    }

    if(currMoney >= moneyForExcursion){
        console.log(`You saved the money for ${countOfAllDays} days.`);
    } else {
        console.log(`You can't save the money.`);
        console.log(countOfAllDays);
    }
}