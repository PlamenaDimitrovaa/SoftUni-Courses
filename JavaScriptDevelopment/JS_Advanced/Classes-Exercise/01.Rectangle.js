class Rectangle{
    constructor(width, height, color){
        this.width = Number(width);
        this.height = Number(height);
        this.color = color;
    }

    calcArea(){
        let result = this.height * this.width;
        return result;
    }
}