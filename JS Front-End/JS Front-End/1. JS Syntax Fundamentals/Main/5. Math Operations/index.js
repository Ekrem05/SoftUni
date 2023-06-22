function solve(number1,number2,action){
    switch(action)
    {
        case "+":
            console.log(number1+number2);
            break;
        case "-":
            console.log(number1-number2);

            break;
        case "*":
            console.log(number1*number2);

            break;
        case "/":
            console.log(number1/number2);

            break;
        case "%":
            console.log(number1%number2);

            break;
        case "**":
            console.log(number1**number2);

            break;
        
    }
}
solve(10,2,'/')
