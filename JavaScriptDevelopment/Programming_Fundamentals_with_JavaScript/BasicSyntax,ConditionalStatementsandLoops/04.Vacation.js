function solve(count, type, day){
    let price = 0;

    if(day === 'Friday'){
        if(type === 'Students'){
            price = count * 8.45;
        }
        else if(type === 'Business'){
            price = count * 10.90;
        }
        else if(type === 'Regular'){
            price = count * 15;
        }
    }
    else if(day === 'Saturday'){
        if(type === 'Students'){
            price = count * 9.80;
        }
        else if(type === 'Business'){
            price = count * 15.60;
        }
        else if(type === 'Regular'){
            price = count * 20;
        }
    }
    else if(day === 'Sunday'){
        if(type === 'Students'){
            price = count * 10.46;
        }
        else if(type === 'Business'){
            price = count * 16;
        }
        else if(type === 'Regular'){
            price = count * 22.50;
        }
    }

    if(type === 'Students' && count >= 30){
        price = price * 0.85;
    }
    else if(type === 'Business' && count >= 100){
        let toreduce = price / count;
        price = price - (10 * toreduce);
    }
    else if(type === 'Regular' && count >= 10 && count <= 20){
        price = price * 0.95;
    }

    console.log(`Total price: ${price.toFixed(2)}`);
}