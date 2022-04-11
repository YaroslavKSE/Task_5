namespace Task_5;

public class BigInteger
{
    private int[] _numbers;

    public BigInteger(string? value)
    {
        int a = 56700;
        int n = 0;
        if (value != null)
        {
            _numbers = new int[value.Length];
            foreach (var digit in value)
            {
                _numbers[n] = Int32.Parse(digit.ToString());
                n++;
            }
        }
    }
    
    public override string ToString()
    {
        var number = "";
        foreach (var digit in _numbers)
        {
            number += digit;
        }
        
        return number;
    }
    public BigInteger Add(BigInteger another)
    {
        int firstExtraLenght = _numbers.Length + 1;
        int secondExtraLenght = another._numbers.Length + 1;
        int firstArrayLen = _numbers.Length - 1;
        int secondArrayLen = another._numbers.Length - 1;
        while (firstArrayLen != -1 && secondArrayLen != -1)
        {
            if (firstArrayLen >= secondArrayLen)
            {
                var addition = _numbers[firstArrayLen] + another._numbers[secondArrayLen];
                if (addition < 10)
                {
                    _numbers[firstArrayLen] = addition;
                }
                else
                {
                    var first = addition.ToString()[0];
                    var second = addition.ToString()[1];
                    
                    if (firstArrayLen - 1 == -1)
                    {
                        int[] temporaryArray = new int[firstExtraLenght];
                        int n = firstExtraLenght;
                        foreach (var digit in _numbers)
                        {
                            temporaryArray[n - 1] = _numbers[n - 2];
                            n--;
                        }
                        _numbers = temporaryArray;
                        firstArrayLen++;
                    }
                    
                    _numbers[firstArrayLen - 1] = Int32.Parse(first.ToString()) + _numbers[firstArrayLen - 1];
                    _numbers[firstArrayLen] = Int32.Parse(second.ToString());
                }
            }
            
            if (firstArrayLen < secondArrayLen)
            {
                var addition = _numbers[firstArrayLen] + another._numbers[secondArrayLen];
                if (addition < 10)
                {
                    another._numbers[secondArrayLen] = addition;
                }
                else
                {
                    var first = addition.ToString()[0];
                    var second = addition.ToString()[1];
                    if (secondArrayLen - 1 == -1)
                    {
                        int[] temporaryArray = new int[secondExtraLenght];
                        int n = secondExtraLenght;
                        
                        foreach (var digit in _numbers)
                        {
                            temporaryArray[n - 1] = _numbers[n - 2];
                            n--;
                        }
                        
                        another._numbers = temporaryArray;
                        secondExtraLenght++;
                        
                    }
                    another._numbers[secondArrayLen - 1] = Int32.Parse(first.ToString()) + another._numbers[secondArrayLen - 1];
                    another._numbers[secondArrayLen] = Int32.Parse(second.ToString());
                }
            }
            firstArrayLen--;
            secondArrayLen--;
        }
        
        return firstArrayLen >= secondArrayLen ? new BigInteger(string.Join("", _numbers)) : another;
    }
    
    // public BigInteger Sub(BigInteger another)
    // {
    //     // return new BigInteger, result of current - another
    // }
}