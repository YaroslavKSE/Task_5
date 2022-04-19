using Task_5;


// ---- SUBTRACTION ----
var binNum = new BigInteger("6408");
var bigNum2 = new BigInteger("5619");
var result2 = binNum - bigNum2;
Console.WriteLine(result2);


// ---- ADDITION ----
Console.WriteLine(binNum + bigNum2);


// ---- Karatsuba ----
var result5 = new BigInteger("120").Multiplication(new BigInteger("120"));
Console.WriteLine(result5);