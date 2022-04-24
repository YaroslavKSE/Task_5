namespace Task_5;

public class BigInteger
{
    private int[] _numbers;
    private bool _isPositive = true;
    public static BigInteger operator +(BigInteger a, BigInteger b) => a.Add(b);
    public static BigInteger operator -(BigInteger a, BigInteger b) => a.Sub(b);
    public static BigInteger operator *(BigInteger a, BigInteger b) => a.Multiplication(b);
    
    public BigInteger(string? value)
    {
        int n = 0;

        if (value != null && !value.Contains('-'))
        {
            _numbers = new int[value.Length];
            foreach (var digit in value)
            {
                _numbers[n] = Int32.Parse(digit.ToString());
                n++;
            }
        }
        else
        {
            _isPositive = false;
            _numbers = new int[value.Length - 1];
            foreach (var digit in value)
            {
                if (digit == '-')
                {
                    continue;
                }

                _numbers[n] = Int32.Parse(digit.ToString());
                n++;
            }
        }
    }

    public override string ToString()
    {
        var number = "";
        var negativeNumber = "-";
        if (_isPositive)
        {
            foreach (var digit in _numbers)
            {
                number += digit;
            }

            return number;
        }

        foreach (var digit in _numbers)
        {
            negativeNumber += digit;
        }

        return negativeNumber;
    }

    private BigInteger Add(BigInteger another)
    {
        int firstExtraLenght = _numbers.Length + 1;
        int secondExtraLenght = another._numbers.Length + 1;
        int firstArrayLen = _numbers.Length - 1;
        int secondArrayLen = another._numbers.Length - 1;
        int[] result = new int[_numbers.Length];
        int[] result2 = new int[another._numbers.Length];
        Array.Copy(_numbers, result, _numbers.Length);
        Array.Copy(another._numbers, result2, another._numbers.Length);
        while (firstArrayLen != -1 && secondArrayLen != -1)
        {
            if (firstArrayLen >= secondArrayLen && another._isPositive)
            {
                var addition = result[firstArrayLen] + another._numbers[secondArrayLen];
                if (addition < 10)
                {
                    result[firstArrayLen] = addition;
                }
                else
                {
                    var first = addition.ToString()[0];
                    var second = addition.ToString()[1];

                    if (firstArrayLen - 1 == -1)
                    {
                        int[] temporaryArray = new int[firstExtraLenght];
                        int n = firstExtraLenght;
                        foreach (var digit in result)
                        {
                            temporaryArray[n - 1] = result[n - 2];
                            n--;
                        }

                        result = temporaryArray;
                        firstArrayLen++;
                    }

                    result[firstArrayLen - 1] = Int32.Parse(first.ToString()) + result[firstArrayLen - 1];
                    result[firstArrayLen] = Int32.Parse(second.ToString());
                }
            }

            if (firstArrayLen < secondArrayLen && another._isPositive)
            {
                var addition = _numbers[firstArrayLen] + result2[secondArrayLen];
                if (addition < 10)
                {
                    result2[secondArrayLen] = addition;
                }
                else
                {
                    var first = addition.ToString()[0];
                    var second = addition.ToString()[1];
                    if (secondArrayLen - 1 == -1)
                    {
                        int[] temporaryArray = new int[secondExtraLenght];
                        int n = secondExtraLenght;

                        foreach (var digit in result)
                        {
                            temporaryArray[n - 1] = result[n - 2];
                            n--;
                        }

                        result2 = temporaryArray;
                        secondExtraLenght++;
                    }

                    result2[secondArrayLen - 1] = Int32.Parse(first.ToString()) + result2[secondArrayLen - 1];
                    result2[secondArrayLen] = Int32.Parse(second.ToString());
                }
            }

            firstArrayLen--;
            secondArrayLen--;
        }

        return firstArrayLen >= secondArrayLen
            ? new BigInteger(string.Join("", result))
            : new BigInteger(string.Join("", result2));
    }

    private BigInteger Sub(BigInteger another)
    {
        int firstArrayLen = _numbers.Length - 1;
        int secondArrayLen = another._numbers.Length - 1;
        int[] result = new int[_numbers.Length];
        int[] result2 = new int[another._numbers.Length];
        Array.Copy(_numbers, result, _numbers.Length);
        Array.Copy(another._numbers, result2, another._numbers.Length);
        
        if (firstArrayLen > secondArrayLen && result.Length > 10 || result2.Length > 10)
        {
            while (firstArrayLen != -1 && secondArrayLen != -1)
            {
                {
                    var subtraction = result[firstArrayLen] - result2[secondArrayLen];
                    if (subtraction >= 0)
                    {
                        result[firstArrayLen] = subtraction;
                    }
                    else
                    {
                        if (result[firstArrayLen] != 0)
                        {
                            result[firstArrayLen - 1] -= 1;
                            if (result[firstArrayLen - 1] == -1)
                            {
                                // result[firstArrayLen - 1] = 9;
                                var n = firstArrayLen;
                                while (result[n] == 0 == false)
                                {
                                    n--;
                                    result[n] = 9;
                                    if (result[n - 1] != 0)
                                    {
                                        result[n - 1] -= 1;
                                        break;
                                    }
                                    
                                }
                            }
                    
                            var toChange = 10 + result[firstArrayLen];
                            toChange -= result2[secondArrayLen];
                            result[firstArrayLen] = toChange;
                            // firstArrayLen--;
                            // secondArrayLen--;
                        }

                        if (result[firstArrayLen] == 0)
                        {
                            var n = firstArrayLen;
                            while (result[n - 1] == 0)
                            {
                                n--;
                                result[n] = 9;
                                if (result[n - 1] != 0)
                                {
                                    result[n - 1] -= 1;
                                    break;
                                }
                            }
                            // if (result[n - 1] != 0)
                            // {
                            //     result[n - 1] -= 1;
                            // }
                            var toChange = 10 + result[firstArrayLen];
                            toChange -= result2[secondArrayLen];
                            result[firstArrayLen] = toChange;
                            // firstArrayLen--;
                            // secondArrayLen--;
                        }
                    }

                    firstArrayLen--;
                    secondArrayLen--;
                }
            }

            if (result[0] == 0)
            {
                SplitFirstHalfBigger(result, 1, out result, out var res2);
                return new BigInteger(string.Join("", res2));
            }
            return new BigInteger(string.Join("", result));
        }

        if (firstArrayLen == secondArrayLen && _numbers[0] > another._numbers[0])
        {
            while (firstArrayLen != -1 && secondArrayLen != -1)
            {
                var subtraction = result[firstArrayLen] - another._numbers[secondArrayLen];
                if (subtraction >= 0)
                {
                    result[firstArrayLen] = subtraction;
                }
                else
                {
                    result[firstArrayLen - 1] -= 1;
                    var toChange = 10 + result[firstArrayLen];
                    toChange -= another._numbers[secondArrayLen];
                    result[firstArrayLen] = toChange;
                }

                firstArrayLen--;
                secondArrayLen--;
            }
            if (result[0] == 0)
            {
                SplitFirstHalfBigger(result, 1, out result, out var res2);
                return new BigInteger(string.Join("", res2));
            }       
            return new BigInteger(string.Join("", result));
        }

        if (firstArrayLen == secondArrayLen && _numbers[0] < another._numbers[0])
        {
            var temporaryArray1 = result;
            var temporaryArray2 = result2;
            result = temporaryArray2;
            result2 = temporaryArray1;

            while (firstArrayLen != -1 && secondArrayLen != -1)
            {
                var subtraction = result[firstArrayLen] - result2[secondArrayLen];
                if (subtraction >= 0)
                {
                    result[firstArrayLen] = subtraction;
                }
                else
                {
                    result[firstArrayLen - 1] -= 1;
                    var toChange = 10 + result[firstArrayLen];
                    toChange -= result2[secondArrayLen];
                    result[firstArrayLen] = toChange;
                }

                firstArrayLen--;
                secondArrayLen--;
            }
            if (result[0] == 0)
            {
                SplitFirstHalfBigger(result, 1, out result, out var res2);
                return new BigInteger(string.Join("", res2));
            }       
            return new BigInteger(string.Join("", result));
        }

        if (result.Length < 10 && result2.Length < 10)
        {
            var resInt = int.Parse(string.Join("", result)) - int.Parse(string.Join("", result2));
            return new BigInteger(resInt.ToString());
        }

        return null;
    }

    private BigInteger PowerNum(int toPower)
    {
        var arrLen = _numbers.Length;
        var secondLen = arrLen + toPower;
        int[] result = new int[secondLen];
        Array.Copy(_numbers, result, _numbers.Length);
        if (_isPositive)
        {
            return new BigInteger(string.Join("", result));
        }

        return new BigInteger(string.Join("", result))
        {
            _isPositive = false
        };
    }

    private int Greater(int firstNum, int secondNum)
    {
        if (firstNum > secondNum)
        {
            return firstNum;
        }

        return secondNum;
    }

    private void Split<T>(T[] source, int index, out T[] first, out T[] last)
    {
        int len2 = source.Length - index;
        first = new T[len2];
        last = new T[index];
        Array.Copy(source, 0, first, 0, len2);
        Array.Copy(source, len2, last, 0, index);
    }
    private void SplitFirstHalfBigger<T>(T[] source, int index, out T[] first, out T[] last)
    {
        int len2 = source.Length - index;
        first = new T[index];
        last = new T[len2];
        Array.Copy(source, 0, first, 0, index);
        Array.Copy(source, index, last, 0, len2);
    }

    private BigInteger Multiplication(BigInteger another)
    {
        var firstMultiplier = new BigInteger(string.Join("", _numbers));
        var result = new BigInteger("");
        Karatsuba(firstMultiplier, another);

        BigInteger Karatsuba(BigInteger first, BigInteger second)
        {
            if (first._numbers.Length < 2 || second._numbers.Length < 2)
            {
                var multResult = Int32.Parse(string.Join("", first._numbers)) *
                             Int32.Parse(string.Join("", second._numbers));
                return new BigInteger(multResult.ToString());
            }

            var dividedArrLen = Greater(first._numbers.Length, second._numbers.Length) / 2;
            Split(first._numbers, dividedArrLen, out var a1, out var b1);
            Split(second._numbers, dividedArrLen, out var c1, out var d1);
            var a = new BigInteger(string.Join("", a1));
            var b = new BigInteger(string.Join("", b1));
            var c = new BigInteger(string.Join("", c1));
            var d = new BigInteger(string.Join("", d1));
            var bd = Karatsuba(b, d);
            var acBd = Karatsuba(a + b, c + d);
            var ac = Karatsuba(a, c);
            var best = (ac.PowerNum(dividedArrLen * 2)) + (acBd - ac - bd).PowerNum(dividedArrLen) + bd;
            result = best;
            return best;
        }

        return result;
        
    }
}