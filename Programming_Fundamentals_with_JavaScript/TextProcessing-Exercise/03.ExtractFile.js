function solve(input){

    let fileNameIndexStart = input.lastIndexOf("\\") + 1;
    let fileExtensionStart = input.lastIndexOf(".") + 1;
    let fileNameIndexEnd = fileExtensionStart - 1;
    let name = input.substring(fileNameIndexStart, fileNameIndexEnd);
    let extension = input.substring(fileExtensionStart);
    console.log(`File name: ${name}`);
    console.log(`File extension: ${extension}`);

}

solve('C:\\Internal\\training-internal\\Template.pptx');