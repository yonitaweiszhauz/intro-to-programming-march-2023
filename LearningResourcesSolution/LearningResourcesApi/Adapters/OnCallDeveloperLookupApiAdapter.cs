using Microsoft.Identity.Client;

namespace LearningResourcesApi.Adapters;

<<<<<<< HEAD:LearningResourcesSolution/LearningResourcesApi/Adapters/OnCallDeveloperLookupApiAdapter.cs
// Create one class per external API that will be called
=======

// Create one of these classes for EACH of the external APIs you will call.
// Each "server" you call in to (http://localhost:1338)
>>>>>>> 388a08c5e60f3c733a73e047e94cb004f61bf5c2:instructor/LearningResourcesSolution/LearningResourcesApi/Adapters/OnCallDeveloperLookupApiAdapter.cs
public class OnCallDeveloperLookupApiAdapter
{
    private readonly HttpClient _httpClient;

    public OnCallDeveloperLookupApiAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
<<<<<<< HEAD:LearningResourcesSolution/LearningResourcesApi/Adapters/OnCallDeveloperLookupApiAdapter.cs
=======
   
>>>>>>> 388a08c5e60f3c733a73e047e94cb004f61bf5c2:instructor/LearningResourcesSolution/LearningResourcesApi/Adapters/OnCallDeveloperLookupApiAdapter.cs

    public async Task<OnCallApiModel> GetOnCallDeveloperAsync()
    {
        var responseMessage = await _httpClient.GetAsync("/oncalldeveloper");
<<<<<<< HEAD:LearningResourcesSolution/LearningResourcesApi/Adapters/OnCallDeveloperLookupApiAdapter.cs
        responseMessage.EnsureSuccessStatusCode(); // 200 - 299? If not BLOW UP
=======
        responseMessage.EnsureSuccessStatusCode(); // 200-299? If not BLOW UP
>>>>>>> 388a08c5e60f3c733a73e047e94cb004f61bf5c2:instructor/LearningResourcesSolution/LearningResourcesApi/Adapters/OnCallDeveloperLookupApiAdapter.cs

        var message = await responseMessage.Content.ReadFromJsonAsync<OnCallApiModel>();

        if(message != null)
        {
            return message;
<<<<<<< HEAD:LearningResourcesSolution/LearningResourcesApi/Adapters/OnCallDeveloperLookupApiAdapter.cs
        }
        else
=======
        } else
>>>>>>> 388a08c5e60f3c733a73e047e94cb004f61bf5c2:instructor/LearningResourcesSolution/LearningResourcesApi/Adapters/OnCallDeveloperLookupApiAdapter.cs
        {
            throw new Exception("Didn't get any data base - do this better in the real world");
        }
    }
}
