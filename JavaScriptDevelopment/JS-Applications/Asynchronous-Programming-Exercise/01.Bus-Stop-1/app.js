async function getInfo() {
    let stopNameElement = document.getElementById('stopName');
    let timeTableElement = document.getElementById('buses');
    
    let stopId = document.getElementById('stopId').value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;

    try {
        timeTableElement.replaceChildren();
        const res = await fetch(url);
    
        // if(res.status !== 200){
        //     throw new Error('Error');
        // }
    
        const data = await res.json();

        stopNameElement.textContent = data.name;

        let entries = Object.entries(data.buses);
        entries.forEach(b => {
            let liElement = document.createElement('li');
            liElement.textContent = `Bus ${b[0]} arrives in ${b[1]} minutes`;
            timeTableElement.appendChild(liElement);
        })
    } catch (error) {
        stopNameElement.textContent = `Error`;
    }
}