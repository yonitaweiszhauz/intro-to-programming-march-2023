namespace StringCalculator;

public class StringCalculator
{
    private int _sum = 0;
    public int Add(string number1)
    {
        return number1 == "" ? 0 : int.Parse(number1);
    }

    public int AddTwo(string number1, string number2)
    {
        return _sum = int.Parse(number1) + int.Parse(number2);
    }

    public int AddMany(string[] numbers)
    {
        int[] intNumbers = Array.ConvertAll(numbers, n => int.Parse(n));
        foreach(int number in intNumbers)
        {
            _sum += number;
        }
        return _sum;
    }

    public int getSum(string number1, string number2)
    {
        return _sum;
    }
}