using Alba;

namespace OnCallDeveloperAPI.IntegrationTests;

public class OnCallDeveloperResourceTests
{
    [Fact]
    public async Task CanGetOnCallDeveloper()
    {
        // "Host" for our API our API will be up and running
        await using var host = await AlbaHost.For<Program>();

        // Scenario
        await host.Scenario(api =>
        {
            api.Get.Url("/oncalldeveloper");
            api.StatusCodeShouldBeOk();
        });
    }
}
