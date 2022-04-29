function solve(speed, area){
    speed = Number(speed);
    let status = "";
    let difference = 0;
    if(area === 'motorway' && speed > 130){
        difference = speed - 130;
        if(difference <= 20){
            status = 'speeding';
        }else if(difference > 20 && difference <= 40){
            status = 'excessive speeding';
        }else{
            status = 'reckless driving';
        }
        console.log(`The speed is ${difference} km/h faster than the allowed speed of 130 - ${status}`);
        return;
    }else if(area === 'motorway' && speed <= 130){
        console.log(`Driving ${speed} km/h in a 130 zone`);
    }

    if(area === 'interstate' && speed > 90){
        difference = speed - 90;
        if(difference <= 20){
            status = 'speeding';
        }else if(difference > 20 && difference <= 40){
            status = 'excessive speeding';
        }else{
            status = 'reckless driving';
        }
        console.log(`The speed is ${difference} km/h faster than the allowed speed of 90 - ${status}`);
        return;
    }else if(area === 'interstate' && speed <= 90){
        console.log(`Driving ${speed} km/h in a 90 zone`);
    }

    if(area === 'city' && speed > 50){
        difference = speed - 50;
        if(difference <= 20){
            status = 'speeding';
        }else if(difference > 20 && difference <= 40){
            status = 'excessive speeding';
        }else{
            status = 'reckless driving';
        }
        console.log(`The speed is ${difference} km/h faster than the allowed speed of 50 - ${status}`);
        return;
    }else if(area === 'city' && speed <= 50){
        console.log(`Driving ${speed} km/h in a 50 zone`);
    }

    if(area === 'residential' && speed > 20){
        difference = speed - 20;
        if(difference <= 20){
            status = 'speeding';
        }else if(difference > 20 && difference <= 40){
            status = 'excessive speeding';
        }else{
            status = 'reckless driving';
        }
        console.log(`The speed is ${difference} km/h faster than the allowed speed of 20 - ${status}`);
        return;
    }else if(area === 'residential' && speed <= 20){
        console.log(`Driving ${speed} km/h in a 20 zone`);
    }
}

solve(40, 'city');