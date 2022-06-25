class SmartHike{
    constructor(username){
        this.username = username;
        this.goals = {}; //an object, representing a key-value pair of a peak’s name and its altitude.
        this.listOfHikes = [];
        this.resources = 100;
    }

    addGoal(peak, altitude){
        if(this.goals.hasOwnProperty(peak)){
            return `${peak} has already been added to your goals`;
        } else{
            this.goals[peak] = altitude;
            return `You have successfully added a new goal - ${peak}`;
        }
    }

    hike(peak, time, difficultyLevel){
        if(this.goals.hasOwnProperty(peak) && this.resources <= 0){
            throw new Error("You don't have enough resources to start the hike");
        } else if(!this.goals.hasOwnProperty(peak)){
            throw new Error(`${peak} is not in your current goals`);
        }

        let difference = this.resources - (time * 10); //?????
        if(difference <= 0){
            return "You don't have enough resources to complete the hike";
        }

        this.resources -= (time * 10); //???
        let currentHike = {
            peak,
            time, 
            difficultyLevel,
        }

        this.listOfHikes.push(currentHike);

        return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`;
    }

    rest(time){
        this.resources += (time * 10);
        if(this.resources >= 100){
            this.resources = 100;
            return `Your resources are fully recharged. Time for hiking!`;
        } else{
            return `You have rested for ${time} hours and gained ${time*10}% resources`;
        }
    }

    showRecord(criteria){

        if(this.listOfHikes.length <= 0){
            return `${this.username} has not done any hiking yet`;
        }

        if(criteria == 'all'){
            let result = [];
            result.push("All hiking records:");
            for (let hike of this.listOfHikes) {
                result.push(`${this.username} hiked ${hike.peak} for ${hike.time} hours`);
            }

            return result.join('\n');
        }

        let listOfHardHikes = this.listOfHikes.filter(x => x.difficultyLevel == 'hard');
        let listOfEasyHikes = this.listOfHikes.filter(x => x.difficultyLevel == 'easy');

        if(criteria == 'easy' && listOfEasyHikes == 0){
            return `${this.username} has not done any easy hiking yet`;
        }

        if(criteria == 'hard' && listOfHardHikes == 0){
            return `${this.username} has not done any hard hiking yet`;
        }

        this.listOfHikes = this.listOfHikes.sort((a,b) => a - b);

        return `${this.username}'s best ${criteria} hike is ${this.listOfHikes[0].peak} peak, for ${this.listOfHikes[0].time} hours`;
    }
}

const user = new SmartHike('Vili');
console.log(user.addGoal('Musala', 2925));
console.log(user.addGoal('Rui', 1706));
console.log(user.hike('Musala', 8, 'hard'));
console.log(user.hike('Rui', 3, 'easy'));
console.log(user.hike('Everest', 12, 'hard'));



