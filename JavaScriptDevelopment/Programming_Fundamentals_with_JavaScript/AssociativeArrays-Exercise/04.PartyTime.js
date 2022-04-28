function solve(input){
    let vip = new Set();
    let regular = new Set();
    while(input[0] != 'PARTY'){
        let guest = input.shift();
        if(Number.isNaN(Number(guest[0]))){
            regular.add(guest);
        }else{
            vip.add(guest);
        }
    }

    for (let guest of input) {
        vip.delete(guest);
        regular.delete(guest);
    }

    console.log(vip.size + regular.size);
    for (let guest of vip) {
        console.log(guest);
    }
    for (let guest of regular) {
        console.log(guest);
    }
}