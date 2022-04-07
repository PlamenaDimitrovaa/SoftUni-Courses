function trekkingMania(input){
    let n = Number(input.shift());

    let p1 = 0;
    let p2 = 0;
    let p3 = 0;
    let p4 = 0;
    let p5 = 0;

    let allPeople = 0;

    for (let i = 0; i < n; i++) {
        let numberOfPeopleOfCurrGroup = Number(input[i]);

        if(numberOfPeopleOfCurrGroup <= 5){
            p1 += numberOfPeopleOfCurrGroup;
        } else if(numberOfPeopleOfCurrGroup >= 6 && numberOfPeopleOfCurrGroup <= 12){
            p2 += numberOfPeopleOfCurrGroup;
        } else if(numberOfPeopleOfCurrGroup >= 13 && numberOfPeopleOfCurrGroup <= 25){
            p3 += numberOfPeopleOfCurrGroup;
        } else if(numberOfPeopleOfCurrGroup >= 26 && numberOfPeopleOfCurrGroup <= 40){
            p4 += numberOfPeopleOfCurrGroup;
        } else{
            p5 += numberOfPeopleOfCurrGroup;
        }

        allPeople += numberOfPeopleOfCurrGroup;
    }

    console.log((p1 / allPeople * 100).toFixed(2) + "%");
    console.log((p2 / allPeople * 100).toFixed(2) + "%");
    console.log((p3 / allPeople * 100).toFixed(2) + "%");
    console.log((p4 / allPeople * 100).toFixed(2) + "%");
    console.log((p5 / allPeople * 100).toFixed(2) + "%");
}
