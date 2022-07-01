function solve() {

    let infoSpan = document.querySelector('.info');
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');

    let stop = {
        next: 'depot',
    }

    async function depart() {
        departBtn.disabled = true;
        const url = ` http://localhost:3030/jsonstore/bus/schedule/${stop.next}`;

        let res = await fetch(url);
        let data = await res.json();

        stop = data;

        infoSpan.textContent = `Next stop ${stop.name}`;
        arriveBtn.disabled = false;
    }

    function arrive() {
        departBtn.disabled = false;
        arriveBtn.disabled = true;
        infoSpan.textContent = `Arriving at ${stop.name}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();