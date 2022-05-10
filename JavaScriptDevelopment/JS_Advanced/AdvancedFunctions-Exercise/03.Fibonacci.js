function solve(){
    let a = 0;
    let b  = 1;

    return () => {
        let c = a + b;
        a = b; 
        b = c;
        return a;
    }
}