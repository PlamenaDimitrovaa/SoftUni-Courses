function solve(array){
    for (const number of array) {
        let reversedNumber = reverse(number);

        if (number === reversedNumber) {
            console.log("true");
        } else{
            console.log("false");
        }
    }

    function reverse(num){
        let reversedNumber = "";

        while (num > 0) {
            reversedNumber += num % 10;
            num = Math.floor(num / 10);
        }

        return Number(reversedNumber);
    }
}
solve(['123', '323','421','121']);