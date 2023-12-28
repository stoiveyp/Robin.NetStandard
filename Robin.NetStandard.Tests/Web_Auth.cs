using System.Diagnostics;
using Robin.NetStandard.Auth;
using Robin.NetStandard.Entities;
using Slack.NetStandard.Tests;

namespace Robin.NetStandard.Tests;

public class WebAuth
{
    [Fact]
    public async Task GetData()
    {
        var res = Utility.ExampleFileContent<ApiResponse<AuthData>>("Web_Auth.json")!;
        var client = new RobinClient(new HttpClient(new ActionHandler(req =>
        {
            Utility.ValidateApiCall(HttpMethod.Get,"auth",req);
        }, res)),"token");

        var response = await client.Auth.TokenInfo();
        Assert.True(Utility.CompareJson(response, "Web_Auth.json", ["created_at", "expire_at", "date"]));
    }
}