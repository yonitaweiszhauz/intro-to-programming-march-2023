
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        if(numbers == "")
        {
            return 0;
        }
        if(numbers.Contains(','))
        {
            var seperatorAt = numbers.IndexOf(',');
            var lhs = int.Parse(numbers.Substring(0, seperatorAt));
            var rhs = int.Parse(numbers.Substring(seperatorAt + 1));

            return lhs + rhs;
        }
        return  int.Parse(numbers);
    }
}
