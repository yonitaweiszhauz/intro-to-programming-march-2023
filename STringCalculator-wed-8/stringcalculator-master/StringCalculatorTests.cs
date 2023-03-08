namespace StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("4", 4)]
    [InlineData("5", 5)]
    public void SingleDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("4", "5", 9)]
    [InlineData("7", "6", 13)]
    public void TwoDigits(string number1, string number2, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.AddTwo(number1, number2);
        Assert.Equal(expected, result);
    }

    // #2
    [Theory]
    string[] nums = { "4", "5" };
    [InlineData(9, nums)]
    // [InlineData("7", "6", 13)]
    public static int unknownNumberAmount(int expected, params string[] numbers)
    {
        var calculator = new StringCalculator();
        var result = calculator.AddMany(numbers);
        Assert.Equal(expected, result);
    }
}
