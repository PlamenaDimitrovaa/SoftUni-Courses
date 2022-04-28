function solve(month, year){
    function getDaysInMonth(year, month) {
        return new Date(year, month, 0).getDate();
      }

    let daysInCurrentMonth = getDaysInMonth(year, month);
    console.log(daysInCurrentMonth);
}

solve(1, 2012)