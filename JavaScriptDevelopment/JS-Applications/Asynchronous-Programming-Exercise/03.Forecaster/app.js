async function attachEvents() {
    document.getElementById('submit').addEventListener('click', getWeather);
}

async function getWeather() {
    try {
        const location = document.getElementById('location');
        const code = await getCode(location.value);
        location.value = '';

        let [todaysWeather, upcomingWeather] = await Promise.all([
            getTodaysWeather(code),
            getUpcomingWeather(code)
        ]);

        addTodaysWeather(todaysWeather);
        addUpcomingWeather(upcomingWeather);
    } catch (error) {
        alert('Error');
    }
}

function addUpcomingWeather(weather) {
    const upcomingElement = document.getElementById('upcoming');
    upcomingElement.innerHTML = '';

    const forecastInfoDiv = document.createElement('div');
    forecastInfoDiv.classList.add('forecast-info');

    Array.from(weather.forecast).forEach(f => {
        const upcomingSpan = document.createElement('span');
        upcomingSpan.className = 'upcoming';
        
        let weatherSymbol = getSymbolWeather(f.condition);
        let symbolSpan = document.createElement('span');
        symbolSpan.innerHTML = weatherSymbol;
        symbolSpan.classList.add('symbol'); 
    
        let temperatureSpan = document.createElement('span');
        temperatureSpan.classList.add('forecast-data');
        temperatureSpan.innerHTML = `${f.low}&#176;/${f.high}&#176;`;
    
        let weatherConditionSpan = document.createElement('span');
        weatherConditionSpan.classList.add('forecast-data');
        weatherConditionSpan.textContent = f.condition;

        upcomingSpan.appendChild(symbolSpan);
        upcomingSpan.appendChild(temperatureSpan);
        upcomingSpan.appendChild(weatherConditionSpan);

        forecastInfoDiv.appendChild(upcomingSpan);
    });

    upcomingElement.appendChild(forecastInfoDiv);
}

function getSymbolWeather(condition) {
    let currentWeatherCode = '';

        switch (condition) {
            case 'Sunny': {
                currentWeatherCode = '&#x2600';
                break;
            }
            case 'Partly sunny': {
                currentWeatherCode = '&#x26C5';
                break;
            }
            case 'Overcast': {
                currentWeatherCode = '&#x2601';
                break;
            }
            case 'Rain': {
                currentWeatherCode = '&#x2614';
                break;
            }
            case 'Degrees': {
                currentWeatherCode = '&#176';
                break;
            }
        }

        return currentWeatherCode;
}

function addTodaysWeather(weather) {
    const currentElement = document.getElementById('current');
    currentElement.innerHTML = '';

    let forecastDiv = document.createElement('div');
    forecastDiv.classList.add('forecasts');

    let weatherSymbol = getSymbolWeather(weather.forecast.condition);
    let symbolSpan = document.createElement('span');
    symbolSpan.innerHTML = weatherSymbol;
    symbolSpan.classList.add('symbol'); 

    let conditionSpan = document.createElement('span');
    conditionSpan.classList.add('condition');

    let locationSpan = document.createElement('span');
    locationSpan.classList.add('forecast-data');
    locationSpan.textContent = weather.name;

    let temperatureSpan = document.createElement('span');
    temperatureSpan.classList.add('forecast-data');
    temperatureSpan.innerHTML = `${weather.forecast.low}&#176;/${weather.forecast.high}&#176;`;

    let weatherConditionSpan = document.createElement('span');
    weatherConditionSpan.classList.add('forecast-data');
    weatherConditionSpan.textContent = weather.forecast.condition;

    conditionSpan.appendChild(locationSpan);
    conditionSpan.appendChild(temperatureSpan);
    conditionSpan.appendChild(weatherConditionSpan);

    forecastDiv.appendChild(symbolSpan);
    forecastDiv.appendChild(conditionSpan);

    currentElement.appendChild(forecastDiv);
    const forecast = document.getElementById('forecast');
    forecast.style.display = 'block';
}

async function getCode(city) {
    const url = `http://localhost:3030/jsonstore/forecaster/locations`;
    const result = await fetch(url);
    const data = await result.json();

    return data.find(l => l.name.toLowerCase() === city.toLowerCase()).code;
}

async function getTodaysWeather(code) {
    const url = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
    const result = await fetch(url);
    const data = await result.json();

    return data;
}

async function getUpcomingWeather(code) {
    const url = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;
    const result = await fetch(url);
    const data = await result.json();

    return data;
}

attachEvents();