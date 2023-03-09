using Alba;
using Moq;
using OnCallDeveloperAPI.Controllers;
using OnCallDeveloperAPI.Models;

namespace OnCallDeveloperAPI.IntegrationTests;

public class OnCallDeveloperResourceTests
{
    [Fact]
    public async Task CanGetOnCallDeveloperDuringBusinessHours()
    {
        var stubbedBusinessClock = new Mock<IProvideTheBusinessClock>();
        stubbedBusinessClock.Setup(clock => clock.IsDuringBusinessHours()).Returns(false);

        builder.ConfigureServices(services =>
        {
            services.AddSingleton<IProvideTheBusinessClock>(stubbedBusinessClock.Object);
        });

        // Scenario
        var response = await host.Scenario(api =>
        {
            api.Get.Url("/oncalldeveloper");
            api.StatusCodeShouldBeOk();
        });

        var expectedResponse = new GetOnCallDeveloperResponse("Michael N.", "555-1212", "mike@aol.com"); 
        var actualResponse = response.ReadAsJson<GetOnCallDeveloperResponse>(); 
        Assert.NotNull(actualResponse);
        Assert.Equal(expectedResponse, actualResponse);
    }

        [Fact]
        public async Task CanGetOnCallDeveloperOutsideBusinessHours()
        {
        // "Host" for our API our API will be up and running
        var stubbedBusinessClock = new Mock<IProvideTheBusinessClock>();
        stubbedBusinessClock.Setup(clock => clock.IsDuringBusinessHours()).Returns(false);

        builder.ConfigureServices(services =>
        {
            services.AddSingleton<IProvideTheBusinessClock>(stubbedBusinessClock.Object);
        });

        // Scenario
        var response = await host.Scenario(api =>
            {
                api.Get.Url("/oncalldeveloper");
                api.StatusCodeShouldBeOk();
            });

            var expectedResponse = new GetOnCallDeveloperResponse("OnCallCorp Customer Service", "800 GOOD-LUCK", "oncall@company.com");
            var actualResponse = response.ReadAsJson<GetOnCallDeveloperResponse>();
            Assert.NotNull(actualResponse);
            Assert.Equal(expectedResponse, actualResponse);
        }
}
