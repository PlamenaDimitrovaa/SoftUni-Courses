function solve(arr, num){
    for (let i = 0; i < num; i++) {
        let lastElement = arr.pop();
        arr.unshift(lastElement);
    }

    console.log(arr.join(' '));
}