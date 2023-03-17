using Microsoft.Identity.Client;

namespace LearningResourcesApi.Adapters;

// Create one class per external API that will be called
public class OnCallDeveloperLookupApiAdapter
{
    private readonly HttpClient _httpClient;

    public OnCallDeveloperLookupApiAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<OnCallApiModel> GetOnCallDeveloperAsync()
    {
        var responseMessage = await _httpClient.GetAsync("/oncalldeveloper");
        responseMessage.EnsureSuccessStatusCode(); // 200 - 299? If not BLOW UP

        var message = await responseMessage.Content.ReadFromJsonAsync<OnCallApiModel>();

        if(message != null)
        {
            return message;
        }
        else
        {
            throw new Exception("Didn't get any data base - do this better in the real world");
        }
    }
}
