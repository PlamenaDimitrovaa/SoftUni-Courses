function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let input = JSON.parse(document.querySelector('#inputs textarea').value);

      let output = {};
      let averageSalary = 0;
      let currAverageSalary = 0;
      let totalSalary = 0;
      let bestName = '';

      for (const line of input) {
         let restaurantInfo = line.split(' - ');
         let restaurantName = restaurantInfo.shift();
         let workersData = restaurantInfo[0].split(', ');
         
         for (const worker of workersData) {
            let [name, salary] = worker.split(' ');
            
            if (!output.hasOwnProperty(restaurantName)) {
               output[restaurantName] = {};
            }

            output[restaurantName][name] = Number(salary);
         }
      }

      let entries = Object.entries(output);

      for (const entry of entries) {
         let values = Object.values(entry[1]);

         for (const salary of values) {
            totalSalary += salary;
         }

         let averageSalary = totalSalary / values.length;

         if (averageSalary > currAverageSalary) {
            currAverageSalary = averageSalary;
            bestName = entry[0];
         }

         totalSalary = 0;
      }

      let restaurantEntries = Object.entries(output[bestName]).sort((a, b) => b[1] - a[1]);
      let print = '';

      restaurantEntries.forEach(a => {
         print += `Name: ${a[0]} With Salary: ${a[1]} `;
      });

      document.querySelector('#bestRestaurant p').textContent = `Name: ${bestName} Average Salary: ${currAverageSalary.toFixed(2)} Best Salary: ${(restaurantEntries[0][1]).toFixed(2)}`;
      document.querySelector('#workers p').textContent = print;
   }
}