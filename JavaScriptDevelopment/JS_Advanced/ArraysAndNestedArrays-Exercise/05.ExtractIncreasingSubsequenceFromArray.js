function solve(arr){
    return arr.reduce((result, current) => {
        if (current >= result[result.length - 1] || result.length === 0) {
            result.push(current);
        }

        return result;
    }, []);
}