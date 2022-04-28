function averageGrade(input){
    let name = input[0];
    let count = 1;
    let grades = 0;

    for(let i = 1; i <= 12; i++){
        let currentGrade = Number(input[i]);
        if(currentGrade === 3 || currentGrade === 2){
            count++;
        }
        
        if(count >= 2){
            console.log(`${name} has been excluded at ${i} grade`);
            return;
        }

        grades += currentGrade;
    }

    console.log(`${name} graduated. Average grade: ${(grades / 12).toFixed(2)}`);
}

averageGrade(["Gosho", 
"5",
"5.5",
"6",
"5.43",
"5.5",
"6",
"5.55",
"5",
"6",
"6",
"5.43",
"5"]);

averageGrade(["Mimi", 
"5",
"6",
"5",
"6",
"5",
"6",
"6",
"2",
"3"]);
