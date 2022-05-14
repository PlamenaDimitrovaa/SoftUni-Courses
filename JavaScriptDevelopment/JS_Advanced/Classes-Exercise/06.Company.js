class Company{
    constructor(){
        this.departments = {};
    }

    addEmployee(name, salary, position, department){

        if(!(name && salary && position && department) || salary < 0){
            throw new Error('Invalid input!');
        }

        let newEmployee = {
            name,
            salary,
            position
        };

        if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = [];
        }

        this.departments[department].push(newEmployee);

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment(){

        let bestAverageSalary = 0;
        let bestCompany = '';
        let departmentsKeys = Object.keys(this.departments);

        for (const department of departmentsKeys) {
            let averageSalary = 0;

            for (const employee of this.departments[department]) {
                averageSalary += employee['salary'];
            }

            averageSalary = averageSalary / this.departments[department].length;

            if (averageSalary > bestAverageSalary) {
                bestAverageSalary = averageSalary;
                bestCompany = department;
            }
        }

        let sortedCompany = this.departments[bestCompany].sort((a, b) => (b['salary'] - a['salary']) || a['name'].localeCompare(b['name']));

        let output = `Best Department is: ${bestCompany}\n`;
        output += `Average salary: ${bestAverageSalary.toFixed(2)}\n`;
        sortedCompany.forEach(e => output += `${e.name} ${e.salary} ${e.position}\n`);

        return output.trim();
    }
}