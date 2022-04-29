function solve(input) {
    let x1 = Number(input[0]);
    let y1 = Number(input[1]);
 
    let x2 = Number(input[2]);
    let y2 = Number(input[3]);
 
    console.log(Number.isInteger(result(x1, y1))
        ? `{${x1}, ${y1}} to {0, 0} is valid`
        : `{${x1}, ${y1}} to {0, 0} is invalid`);
    console.log(Number.isInteger(result(x2, y2))
        ? `{${x2}, ${y2}} to {0, 0} is valid`
        : `{${x2}, ${y2}} to {0, 0} is invalid`);
 
    console.log(Number.isInteger(result((x1-x2), (y1-y2)))
        ? `{${x1}, ${y1}} to {${x2}, ${y2}} is valid`
        : `{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
 
 
    function result(x, y) {
        return Math.sqrt(x ** 2 + y ** 2);
    }
}