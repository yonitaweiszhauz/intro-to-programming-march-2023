<<<<<<< HEAD:LearningResourcesSolution/LearningResourcesApi/controllers/StatusController.cs
﻿namespace LearningResourcesApi.Controllers;
=======
﻿

namespace LearningResourcesApi.Controllers;
>>>>>>> 388a08c5e60f3c733a73e047e94cb004f61bf5c2:instructor/LearningResourcesSolution/LearningResourcesApi/Controllers/StatusController.cs

public class StatusController : ControllerBase
{
    private readonly ILookupOnCallDevelopers _onCallDeveloperLookup;

    public StatusController(ILookupOnCallDevelopers onCallDeveloperLookup)
    {
        _onCallDeveloperLookup = onCallDeveloperLookup;
    }

    [HttpGet("/status")]
    public async Task<ActionResult> GetServiceStatus()
    {
        StatusHelpInfo helpInfo;
        try
        {
<<<<<<< HEAD:LearningResourcesSolution/LearningResourcesApi/controllers/StatusController.cs
            helpInfo = await _onCallDeveloperLookup.GetCurrentOnCallDeveloperAsync();
        }
        catch (Exception)
        {
            // What's the plan b? Maybe notify someone?
            helpInfo = new StatusHelpInfo("Help Info Unavailable - Try Again Later", new Dictionary<string, string>());
=======
           helpInfo = await _onCallDeveloperLookup.GetCurrentOnCallDeveloperAsync();
        }
        catch (Exception)
        {
            // What's the plan b? Maybe notify someone?
            helpInfo = new StatusHelpInfo("Help Info Unavailable - Try Again Later", new Dictionary<string, string>());
            
>>>>>>> 388a08c5e60f3c733a73e047e94cb004f61bf5c2:instructor/LearningResourcesSolution/LearningResourcesApi/Controllers/StatusController.cs
        }
        var response = new StatusResponse(StatusLevel.OnFire, DateTime.Now.AddDays(-268), new List<DateTime>(), helpInfo);
        return Ok(response);
    }
}
