using Task_5;


// ---- SUBTRACTION ----
var binNum = new BigInteger("46546464564564123");
var bigNum2 = new BigInteger("81379281731982731");
var result2 = binNum - bigNum2;
Console.WriteLine(result2);

// ---- ADDITION ----
Console.WriteLine(binNum + bigNum2);


// ---- Karatsuba ----
var result5 = new BigInteger("5678").Multiplication(new BigInteger("1234"));
Console.WriteLine(result5);