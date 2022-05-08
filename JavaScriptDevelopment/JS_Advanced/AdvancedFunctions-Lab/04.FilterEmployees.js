function solve(data, criteria){
    let objArray = JSON.parse(data);
    let info = criteria.split('-');
    let name = info[0];
    let value = info[1];

    let output = objArray.filter(x => x[name] === value).map((x, count) => `${count}. ${x['first_name']} ${x['last_name']} - ${x['email']}`);
    for (let element of output) {
        console.log(element);
    }
}