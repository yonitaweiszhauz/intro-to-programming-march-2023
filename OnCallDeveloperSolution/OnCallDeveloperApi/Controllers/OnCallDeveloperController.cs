﻿namespace OnCallDeveloperAPI.Controllers;

public class OnCallDeveloperController : ControllerBase
{
    // Get /oncalldeveloper -> 200 Ok
    [HttpGet("/oncalldeveloper")]
    public ActionResult GetOnCallDeveloper()
    {
        return Ok();
    }
}
