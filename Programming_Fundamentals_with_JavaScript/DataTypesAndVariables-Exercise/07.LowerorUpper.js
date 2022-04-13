// String.prototype.isUpperCase = function() {
//     return this.valueOf().toUpperCase() === this.valueOf();
// };


function solve(character) 
{
    if (character === character.toUpperCase()) {
      console.log("upper-case");
    } else {
      console.log("lower-case");
    }
}

// function isLowerCase(str)
// {
//     return str == str.toLowerCase() && str != str.toUpperCase();
// }

solve('L');
solve('l');
