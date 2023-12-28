using System.Diagnostics;
using Robin.NetStandard.Auth;
using Robin.NetStandard.Entities;
using Slack.NetStandard.Tests;

namespace Robin.NetStandard.Tests;

public class WebOrg
{
    [Fact]
    public async Task GetById()
    {
        var res = Utility.ExampleFileContent<ApiResponse<Organization>>("Web_Org.json")!;
        var client = new RobinClient(new HttpClient(new ActionHandler(req =>
        {
            Utility.ValidateApiCall(HttpMethod.Get,"/organizations/34",req);
        }, res)),"token");

        var response = await client.Organization.Get(34);
        Assert.True(Utility.CompareJson(response, "Web_Org.json", ["created_at", "updated_at"]));
    }
}