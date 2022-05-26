let expect = require('chai').expect;
let companyAdministration = require('./companyAdministration.js');

describe('Company Administration Tests', () => {
    describe('Hiring Employee Tests', () => {
        it('hiring employee should accept the correct parameters', () => {
            expect(companyAdministration.hiringEmployee('Plamena', 'Programmer', 3)).to.equals(`Plamena was successfully hired for the position Programmer.`)
        })

        it('hiring employee should accept the correct parameters', () => {
            expect(companyAdministration.hiringEmployee('Plamena', 'Programmer', 2)).to.equals(`Plamena is not approved for this position.`)
        })

        it('hiring employee should throw an error for invalid parameters', () => {
            expect(() => companyAdministration.hiringEmployee('Plamena', 'Vet', 2)).to.throw(Error, `We are not looking for workers for this position.`)
        })
    })

    describe('Calculate Salary Tests', () => {
        it('calculate salary should accept the correct parameters', () => {
            expect(() => companyAdministration.calculateSalary('somestring')).to.throw(Error, 'Invalid hours');
        })

        it('calculate salary should accept the correct parameters', () => {
            expect(() => companyAdministration.calculateSalary(-5)).to.throw(Error, 'Invalid hours');
        })

        it('calculate salary should work correct', () => {
            expect(companyAdministration.calculateSalary(2)).to.equals(30);
        })

        it('calculate salary should work correct', () => {
            expect(companyAdministration.calculateSalary(161)).to.equals(3415);
        })
    })

    describe('Fired Employee Tests', () => {
        it('fired employee should accept the correct parameters', () => {
            expect(() => companyAdministration.firedEmployee('pl', 5)).to.throw(Error, 'Invalid input');
        })

        it('fired employee should accept the correct parameters', () => {
            expect(() => companyAdministration.firedEmployee(['Plamena', 'Oreo', 'Vais'], 'pl')).to.throw(Error, 'Invalid input');
        })

        it('fired employee should accept the correct parameters', () => {
            expect(() => companyAdministration.firedEmployee(['Plamena', 'Oreo', 'Vais'], -1)).to.throw(Error, 'Invalid input');
        })

        it('fired employee should accept the correct parameters', () => {
            expect(() => companyAdministration.firedEmployee(['Plamena', 'Oreo', 'Vais'], 3)).to.throw(Error, 'Invalid input');
        })

        it('fired employee should accept the correct parameters', () => {
            expect(() => companyAdministration.firedEmployee(['Plamena', 'Oreo', 'Vais'], 4)).to.throw(Error, 'Invalid input');
        })

        it('fired employee should work correct', () => {
            expect(companyAdministration.firedEmployee(['Plamena', 'Oreo', 'Vais'], 2)).to.equals('Plamena, Oreo');
        })
    })
})
// firedEmployee(employees, index) {

//     let result = [];

//     if (!Array.isArray(employees) || !Number.isInteger(index) || index < 0 || index >= employees.length) {
//         throw new Error("Invalid input");
//     }
//     for (let i = 0; i < employees.length; i++) {
//         if (i !== index) {
//             result.push(employees[i]);
//         }
//     }
//     return result.join(", ");
// }
// }