class Point{
    constructor(x, y){
        this.x = x;
        this.y = y;
    }

    static distance(first, second){
        let firstNum = first.x - second.x;
        let secondNum = first.y - second.y;
        let distance = Math.sqrt(firstNum ** 2 + secondNum ** 2);

        return distance;
    }
}