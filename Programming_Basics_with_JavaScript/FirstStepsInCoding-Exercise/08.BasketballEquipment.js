function calculate(input)
{
    let yearTaxe = Number(input[0]);
    let shoesCount = yearTaxe * 0.6;
    let sportWearCount = shoesCount * 0.8;
    let ballCount = sportWearCount / 4;
    let accessoriesCount = ballCount / 5;
    let totalCount = yearTaxe + shoesCount + sportWearCount + ballCount + accessoriesCount;
    console.log(totalCount);
}

calculate(["365"]);