function solve(commands){
    let array = commands.shift().split(' ').map(Number);

    for (let i = 0; i < commands.length; i++) {
        let [command, firstNum, secondNum] = commands[i].split(' ');

        firstNum = Number(firstNum);
        secondNum = Number(secondNum);

        switch (command) {
            case 'Add':
                Add(firstNum);
                break;
            case 'Remove':
                Remove(firstNum);
                break;
            case 'RemoveAt':
                RemoveAt(firstNum);
                break;
            case 'Insert':
                Insert(firstNum, secondNum);
                break;
        }
    }

    function Add(number){
        array.push(number);
    }

    function Remove(number){
        array = array.filter(x => x !== number);
    }

    function RemoveAt(index){
        array.splice(index, 1);
    }

    function Insert(number, index){
        array.splice(index, 0, number);
    }

    console.log(array.join(' '));
}
