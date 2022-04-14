function solve(input){
    let days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
    if(input >= 1 && input <= 7){
        if(input === 1){
            console.log(days[0]);
        }else if(input === 2){
            console.log(days[1]);
        }else if(input === 3){
            console.log(days[2]);
        }else if(input === 4){
            console.log(days[3]);
        }else if(input === 5){
            console.log(days[4]);
        }else if(input === 6){
            console.log(days[5]);
        }else if(input === 7){
            console.log(days[6]);
        }
    }else{
        console.log('Invalid day!')
    }
}