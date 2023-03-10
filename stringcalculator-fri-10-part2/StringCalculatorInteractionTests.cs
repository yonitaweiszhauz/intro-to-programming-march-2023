using System.Runtime.InteropServices;

namespace StringCalculator;

public class StringCalculatorInteractionTests
{
    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("42", 42)]
    [InlineData("", 0)]
    public void ResultsAreLogged(string numbers, string expected)
    {
        // Given 
        var mockedLogger = new Mock<ILogger>();
        var calculator = new StringCalculator(mockedLogger.Object, new Mock<IWebService>().Object);

        // When
        calculator.Add(numbers);

        // Then
        // did the calculator call the Write method on the
        // logger with the value "6"
        mockedLogger.Verify(m => m.Write(expected));
    }

    [Theory]
    [InlineData("1", "Logging Failed")]
    [InlineData("2", "Logging Failed")]
    // [InlineData("2", "Blamno")]
    public void WebServiceIsNotifedIfLoggerFails(string numbers, string expectedMessage)
    {
        // Given
        // testing string calculator's add method
        // Scenario: logger calls web service when it blows up
        var stubbedLogger = new Mock<ILogger>();
        stubbedLogger.Setup(logger => logger.Write(It.IsAny<string>())).Throws<LoggingException>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);
        
        // When
        calculator.Add(numbers);         
        
        // Then        
        mockedWebService.Verify(w => w.LoggingFailed(expectedMessage));
    }


}
