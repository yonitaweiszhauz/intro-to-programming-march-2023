namespace OnCallDeveloperAPI.Controllers;

public class OnCallDeveloperController : ControllerBase
{
    private readonly IProvideTheBusinessClock _businessClock;

    public OnCallDeveloperController(IProvideTheBusinessClock businessClock)
    {
        _businessClock = businessClock;
    }

    // Get /oncalldeveloper -> 200 Ok
    [HttpGet("/oncalldeveloper")]
    public ActionResult GetOnCallDeveloper()
    {
        Thread.Sleep(3000); // don't do this IRL!!!!
        GetOnCallDeveloperResponse response;
        if (_businessClock.IsDuringBusinessHours())
        {
            response =
            new GetOnCallDeveloperResponse("Michael N.", "555-1212", "mike@aol.com");
        }
        else
        {
            response =
            new GetOnCallDeveloperResponse("OnCallCorp Customer Service", "800 GOOD-LUCK", "oncall@company.com");
        }
        return Ok(response); // 200 status code
    }
}
