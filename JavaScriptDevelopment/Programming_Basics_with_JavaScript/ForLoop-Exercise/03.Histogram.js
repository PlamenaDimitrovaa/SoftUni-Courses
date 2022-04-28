function histogram(input){
    let n = Number(input[0]);
    let p1 = 0;
    let p2 = 0;
    let p3 = 0;
    let p4 = 0;
    let p5 = 0;

    for(let i = 1; i <= n; i++){
        let current = Number(input[i]);
        if(current < 200){
            p1++;
        }else if(current >= 200 && current <= 399){
            p2++;
        }else if(current >= 400 && current <= 599){
            p3++;
        }else if(current >= 600 && current <= 799){
            p4++;
        }else if(current >= 800){
            p5++;
        }
    }

    let count = p1 + p2 + p3 + p4 + p5;

    console.log(`${((p1 / count)* 100).toFixed(2)}%`);
    console.log(`${((p2 / count)* 100).toFixed(2)}%`);
    console.log(`${((p3 / count)* 100).toFixed(2)}%`);
    console.log(`${((p4 / count)* 100).toFixed(2)}%`);
    console.log(`${((p5 / count)* 100).toFixed(2)}%`);
}