function solve(firstChar, secondChar){
    let first = firstChar.charCodeAt(0);
    let last = secondChar.charCodeAt(0);
    let output = "";
    return first < last ? charsInLine(first, last) : charsInLine(last, first);
    function charsInLine(a, b){
        for (let i = a + 1; i < b; i++) {
            output += String.fromCharCode(i) + " ";
        }

        return output;
    }
}
