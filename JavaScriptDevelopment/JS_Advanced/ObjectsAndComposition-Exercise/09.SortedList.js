function createSortedList(){
    return {
        result: [],
        add(el) {
            this.result.push(el);
            this.result.sort((a, b) => a - b);
        },
        remove(index){
            if (this.isItCorrect(index)) {
                this.result.splice(index, 1);
            }
        },
        get(index){
            if (this.isItCorrect(index)) {
                return this.result[index];
            }
        },
        get size(){
            return this.result.length;
        },
        isItCorrect(index){
            return index >= 0 && index < this.result.length;
        },
    }
}