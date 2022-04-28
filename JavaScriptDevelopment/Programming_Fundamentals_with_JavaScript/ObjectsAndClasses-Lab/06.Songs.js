function solve(input){
    class Song{
        constructor(typeList, name, time){
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let numberOfSongs = Number(input.shift());
    let songs = [];
    for (let i = 0; i < numberOfSongs; i++) {
        let line = input.shift();
        let [typeList, name, time] = line.split("_");
        songs.push(new Song(typeList, name, time));
    }

    let search = input.shift();
    if (search === "all") {
        printSongs(songs);
    } 
    else{
        let sorted = songs.filter((s) => s.typeList === search);
        printSongs(sorted);
    }

    function printSongs(array){
        for (let song of array) {
            console.log(song.name);
        }
    }
}