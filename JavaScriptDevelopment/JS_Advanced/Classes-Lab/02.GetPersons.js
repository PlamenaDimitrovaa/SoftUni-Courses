function returning(){
    class Person{
        constructor(firstName, lastName, age, email){
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
        }
    
        toString(){
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
        }
    }
    
    let result = [];
    let first = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
    let second = new Person('SoftUni');
    let third = new Person('Stephan', 'Johnson', 25);
    let fourth = new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com');
    result.push(first);
    result.push(second);
    result.push(third);
    result.push(fourth);
    return result;
}

console.log(returning());