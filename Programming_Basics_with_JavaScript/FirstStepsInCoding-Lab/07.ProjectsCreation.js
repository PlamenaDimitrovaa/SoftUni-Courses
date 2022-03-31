function completeProjects(input)
{
    let name = input[0];
    let projectsCount = Number(input[1]);
    let neededHours = projectsCount * 3;
    console.log(`The architect ${name} will need ${neededHours} hours to complete ${projectsCount} project/s.`);
}

completeProjects(['George', 4]);
completeProjects(['Sanya', 9]);
