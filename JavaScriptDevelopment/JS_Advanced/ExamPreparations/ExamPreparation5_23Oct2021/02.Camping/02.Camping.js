class SummerCamp{
    constructor(organizer, location){
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            "child": 150,
            "student": 300,
            "collegian": 500,
        }

        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money){
        if(!this.priceForTheCamp.hasOwnProperty(condition)){
            throw new Error("Unsuccessful registration at the camp.");
        }

        if(this.listOfParticipants.some(x => x.name == name)){
            return `The ${name} is already registered at the camp.`;
        }

        if(condition == "child" && money < 150){
            return `The money is not enough to pay the stay at the camp.`;
        }

        if(condition == "student" && money < 300){
            return `The money is not enough to pay the stay at the camp.`;
        }

        if(condition == "collegian" && money < 500){
            return `The money is not enough to pay the stay at the camp.`;
        }

        let currentObject = {
            name, 
            condition, 
            power: 100,
            wins: 0,
        }

        this.listOfParticipants.push(currentObject);

        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name){
        if(!this.listOfParticipants.some(x => x.name == name)){
            throw new Error(`The ${name} is not registered in the camp.`);
        }
        else{
            this.listOfParticipants = this.listOfParticipants.filter(x => x.name !== name);
            return `The ${name} removed successfully.`;
        }
    }

    timeToPlay(typeOfGame, participant1, participant2){
        if(typeOfGame == "WaterBalloonFights"){
            let firstParticipant = this.listOfParticipants.find(p => p.name === participant1);
            let secondParticipant = this.listOfParticipants.find(p => p.name === participant2);

            if (!firstParticipant || !secondParticipant) {
                throw new Error(`Invalid entered name/s.`);
            }

            if (firstParticipant.condition !== secondParticipant.condition) {
                throw new Error(`Choose players with equal condition.`);
            }

            if(firstParticipant.power > secondParticipant.power){
                firstParticipant.wins++;
                return `The ${firstParticipant.name} is winner in the game ${typeOfGame}.`;
            } else if(firstParticipant.power < secondParticipant.power){
                secondParticipant.wins++;
                return `The ${secondParticipant.name} is winner in the game ${typeOfGame}.`;
            } else{
                return 'There is no winner.'
            }

        } else if (typeOfGame === 'Battleship') {
            let firstParticipant = this.listOfParticipants.find(p => p.name === participant1);

            if (!firstParticipant) {
                throw new Error(`Invalid entered name/s.`);
            }

            firstParticipant.power += 20;
            return `The ${firstParticipant.name} successfully completed the game ${typeOfGame}.`;
        }
    }

    toString(){
        let result = [];
        result.push(`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`);
        this.listOfParticipants
        .sort((a, b) => b.wins - a.wins)
        .forEach(p => result.push(`${p.name} - ${p.condition} - ${p.power} - ${p.wins}`));  
        return result.join('\n');
    }
}