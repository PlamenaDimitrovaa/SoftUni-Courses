function solve(nums){
   return nums.sort((a, b) => a - b).slice(0, 2).join(' ');
}