namespace LearningResourcesApi.Models;

/*
 {
    "status": "Normal",
    "lastOutage": "185 Days Ago",
<<<<<<< HEAD:LearningResourcesSolution/LearningResourcesApi/Models/StatusModels.cs
    "upcomingScheduledOutages": [],
=======
    "upcomingScheduledOutages: [],
>>>>>>> 388a08c5e60f3c733a73e047e94cb004f61bf5c2:instructor/LearningResourcesSolution/LearningResourcesApi/Models/StatusModels.cs
    "forHelp": {
        "contact": "Bob Smith",
        "contactInfo": {
            "email": "Bob@aol.com",
            "phone": "555-1212"
<<<<<<< HEAD:LearningResourcesSolution/LearningResourcesApi/Models/StatusModels.cs
        }
    }
}
 */

// Status is always "Normal", "Degraded", "OnFire"
public enum StatusLevel { Normal, Degraded, OnFire }
public record StatusResponse(StatusLevel status, DateTime lastOutage, List<DateTime> upcomingOutages, StatusHelpInfo ForHelp); 
public record StatusHelpInfo(string Contact, Dictionary<string, string> contactInfo);
=======

        }
    }
  }
*/

// Status is always "Normal", "Degraded", "OnFire"
public enum StatusLevel { Normal, Degraded, OnFire }
public record StatusResponse(StatusLevel status, DateTime lastOutage, List<DateTime> upcomingOutages, StatusHelpInfo ForHelp);

public record StatusHelpInfo (string Contact, Dictionary<string,string> contactInfo);
>>>>>>> 388a08c5e60f3c733a73e047e94cb004f61bf5c2:instructor/LearningResourcesSolution/LearningResourcesApi/Models/StatusModels.cs
