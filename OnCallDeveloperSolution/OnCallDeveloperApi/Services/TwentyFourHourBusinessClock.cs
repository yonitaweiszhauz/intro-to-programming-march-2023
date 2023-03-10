namespace OnCallDeveloperAPI.Services;

using OnCallDeveloperAPI.Controllers;

public class TwentyFourHourBusinessClock : IProvideTheBusinessClock
{
    public bool IsDuringBusinessHours()
    {
        return true;
    }
}