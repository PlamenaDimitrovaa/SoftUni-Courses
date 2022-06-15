function loadCommits() {
    const username = document.getElementById('username');
    const repo = document.getElementById('repo');

    const url = `https://api.github.com/repos/${username.value}/${repo.value}/commits`;

    fetch(url)
        .then(response => response.json())
        .then(data => {
            const ulElement = document.getElementById('commits');
            ulElement.innerHTML = '';

            const keys = Object.keys(data);
            keys.forEach(key => {
                const currCommit = data[key].commit;
                console.log(data[key]);
                const liElement = document.createElement('li');
                liElement.textContent = `${currCommit.author.name}: ${currCommit.message}`;
                ulElement.appendChild(liElement);
            })
        })
}