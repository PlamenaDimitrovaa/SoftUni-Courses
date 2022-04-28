function cats(array){
    class Cat{
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow(){
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    let cats = [];
    for (let i = 0; i < array.length; i++) {
        let catInfo = array[i].split(" ");

        let [name, age] = catInfo;

        cats.push(new Cat(name, age));
    }

    for (let cat of cats) {
        cat.meow();
    }
}