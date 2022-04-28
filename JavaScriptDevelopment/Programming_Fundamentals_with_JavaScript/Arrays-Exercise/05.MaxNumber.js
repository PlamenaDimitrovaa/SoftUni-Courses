function solve(array){
    let result = [];

    for (let i = 0; i < array.length; i++) {
        let isMax = true;
        for (let j = i + 1; j < array.length; j++) {
            if(array[i] <= array[j]) {
                isMax = false;
                break;
            }
        }

        if (isMax) {
            result.push(array[i]);
        }
    }

    console.log(result.join(" "));
}
