
namespace Task_5;

public class BigInteger
{
    private int[] _numbers;
    private bool _isPositive = true;

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
    
    public void Sub(BigInteger another)
    {
        int firstArrayLen = _numbers.Length - 1;
        int secondArrayLen = another._numbers.Length - 1;
        
        if (firstArrayLen > secondArrayLen)
        {
            while (firstArrayLen != -1 && secondArrayLen != -1)
            {
                {
                    var subtraction = _numbers[firstArrayLen] - another._numbers[secondArrayLen];
                    if (subtraction >= 0)
                    {
                        _numbers[firstArrayLen] = subtraction;
                    }
                    else
                    {
                        if (_numbers[firstArrayLen] != 0)
                        {
                            _numbers[firstArrayLen - 1] -= 1;
                            var toChange = 10 + _numbers[firstArrayLen];
                            toChange -= another._numbers[secondArrayLen];
                            _numbers[firstArrayLen] = toChange;
                        }
                        else
                        {
                            while (true)
                            {
                                var counter = 0;
                                foreach (var variable in _numbers.Reverse())
                                {
                                    if (variable != 0)
                                    {
                                        var toChange = 10 + _numbers[firstArrayLen];
                                        toChange -= another._numbers[secondArrayLen];
                                        _numbers[firstArrayLen] = toChange;
                                    }

                                    counter++;
                                    if (firstArrayLen - counter < 0)
                                    {
                                        continue;
                                    }

                                    if (_numbers[firstArrayLen - counter] == 0)
                                    {
                                        _numbers[firstArrayLen - counter] = 9;
                                    }
                                    else
                                    {
                                        _numbers[firstArrayLen - counter] -= 1;
                                    }
                                }

                                break;
                            }
                        }
                    }
                    firstArrayLen--;
                    secondArrayLen--;
                }
            }
            return;
        }

        if (firstArrayLen == secondArrayLen && _numbers[0] > another._numbers[0])
        {
            while (firstArrayLen != -1 && secondArrayLen != -1)
            {
                var subtraction = _numbers[firstArrayLen] - another._numbers[secondArrayLen];
                if (subtraction >= 0)
                {
                    _numbers[firstArrayLen] = subtraction;
                }
                else
                {
                    _numbers[firstArrayLen - 1] -= 1;
                    var toChange = 10 + _numbers[firstArrayLen];
                    toChange -= another._numbers[secondArrayLen];
                    _numbers[firstArrayLen] = toChange;
                }

                firstArrayLen--;
                secondArrayLen--;
            }

            return;
        }

        if (firstArrayLen == secondArrayLen && _numbers[0] < another._numbers[0])
        {
            var temporaryArray1 = _numbers;
            var temporaryArray2 = another._numbers;
            _numbers = temporaryArray2;
            another._numbers = temporaryArray1;

            while (firstArrayLen != -1 && secondArrayLen != -1)
            {
                var subtraction = _numbers[firstArrayLen] - another._numbers[secondArrayLen];
                if (subtraction >= 0)
                {
                    _numbers[firstArrayLen] = subtraction;
                }
                else
                {
                    _numbers[firstArrayLen - 1] -= 1;
                    var toChange = 10 + _numbers[firstArrayLen];
                    toChange -= another._numbers[secondArrayLen];
                    _numbers[firstArrayLen] = toChange;
                }

                firstArrayLen--;
                secondArrayLen--;
            }
            _isPositive = false;
            
        }
        
    }
}