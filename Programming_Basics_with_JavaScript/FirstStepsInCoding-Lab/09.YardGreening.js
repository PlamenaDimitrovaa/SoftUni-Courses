function count(input){
    let squareMeters = Number(input[0]);

    let priceForOneSquareMeter = 7.61;

    let priceWithoutDiscount = squareMeters * priceForOneSquareMeter;
    let finalPrice = priceWithoutDiscount - (priceWithoutDiscount * 0.18);

    console.log(`The final price is: ${finalPrice} lv.`);
    console.log(`The discount is: ${priceWithoutDiscount * 0.18} lv.`);
}

count(["550"]);
count(["150"]);
