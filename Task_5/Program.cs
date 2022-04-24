using Task_5;


// ---- SUBTRACTION ----
var binNum = new BigInteger("10000000005");
var bigNum2 = new BigInteger("999954621");
var result2 = binNum - bigNum2;
Console.WriteLine(result2);


// ---- ADDITION ----
Console.WriteLine(binNum + bigNum2);


// ---- Karatsuba ----
var result5 = new BigInteger("5678") * (new BigInteger("1234"));
Console.WriteLine(result5);

// int[] array = {0, 5, 9};
// int[] array2 = {new()};
// Split2(array, 1, out array, out array2);
//
// void Split<T>(T[] source, int index, out T[] first, out T[] last)
// {
//     int len2 = source.Length - index;
//     first = new T[len2];
//     last = new T[index];
//     Array.Copy(source, 0, first, 0, len2);
//     Array.Copy(source, len2, last, 0, index);
//     
//     
// }
//
// void Split2<T>(T[] source, int index, out T[] first, out T[] last)
// {
//     int len2 = source.Length - index;
//     first = new T[index];
//     last = new T[len2];
//     Array.Copy(source, 0, first, 0, index);
//     Array.Copy(source, index, last, 0, len2);
// }
// Console.WriteLine();