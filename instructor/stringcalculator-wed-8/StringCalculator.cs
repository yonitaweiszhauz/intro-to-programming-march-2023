
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        var delimiters = new List<char> { '\n', ',' };
        if(numbers.StartsWith("//"))
        {
            var delim = numbers[2];
            delimiters.Add(delim);
            numbers = numbers.Substring(4);

        }
       
        if(numbers == "")
        {
            return 0;
        }
        var nums = numbers.Split(delimiters.ToArray())
            .Select(int.Parse);

        var negatives = nums.Where(n => n < 0);
        if(negatives.Count() > 0)
        {
            var message = String.Join(',', negatives.ToArray());
            throw new NoNegativeNumbersException(message);
        }

        return nums.Sum();

    }
}
