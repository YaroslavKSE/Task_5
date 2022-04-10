namespace Task_5;

public class BigInteger
{
    private readonly int[] _numbers;

    public BigInteger(string value)
    {
        int n = 0;
        _numbers = new int[value.Length];
        foreach (var digit in value)
        {
            _numbers[n] = Int32.Parse(digit.ToString());
            n++;
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
    public string Add(BigInteger another)
    {
        // STILL NOT READY CASES:
        // 845 + 535
        
        int firstArrayLen = _numbers.Length - 1;
        int secondArrayLen = another._numbers.Length - 1;
        while (firstArrayLen != -1 || secondArrayLen != -1)
        {
            if (firstArrayLen >= secondArrayLen)
            {
                var addition = 0;
                addition = _numbers[firstArrayLen] + another._numbers[secondArrayLen];
                if (addition < 10)
                {
                    _numbers[firstArrayLen] = addition;
                }
                else
                {
                    var first = addition.ToString()[0];
                    var second = addition.ToString()[1];
                    _numbers[firstArrayLen - 1] = Int32.Parse(first.ToString()) + _numbers[firstArrayLen - 1];
                    _numbers[firstArrayLen] = Int32.Parse(second.ToString());
                }
            }
                
            firstArrayLen--;
            secondArrayLen--;
        }
        
        return _numbers.ToString();
    }
    
    // public BigInteger Sub(BigInteger another)
    // {
    //     // return new BigInteger, result of current - another
    // }
}