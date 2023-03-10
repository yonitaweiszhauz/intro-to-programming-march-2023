namespace StringCalculator;

public class StringCalculator
{

    private readonly ILogger _logger;
    private readonly IWebService _webService;

    public StringCalculator(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
    }

    public int Add(string numbers)
    {
        int total = numbers == "" ? 0 : numbers.Split(',', '\n').Select(number => int.Parse(number)).Sum();

        try
        {
            _logger.Write(total.ToString());
        }
        catch(LoggingException)
        {

            // WTCYWYH
            _webService.LoggingFailed("Logging Failed");
        }
        return total;
    }
}

public interface IWebService
{
    void LoggingFailed(string failureMessage);
}