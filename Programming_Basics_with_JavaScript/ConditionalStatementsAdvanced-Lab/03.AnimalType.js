function aninamType(input)
{
    let animal = input[0];
    if(animal == "dog")
    {
        console.log('mammal');
    }
    else if(animal == 'snake' || animal == "crocodile" || animal == "tortoise")
    {
        console.log('reptile');
    }
    else if(animal == 'cat')
    {
        console.log('unknown');
    }
}