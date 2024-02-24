using Robin.NetStandard.Auth;
using Robin.NetStandard.Entities;
using Robin.NetStandard.Users;
using Slack.NetStandard.Tests;

namespace Robin.NetStandard.Tests;

public class WebUsers
{
    [Fact]
    public async Task Get()
    {
        var res = Utility.ExampleFileContent<ApiResponse<User>>("Web_User.json")!;
        var client = (IRobinApi)new RobinClient(new HttpClient(new ActionHandler(req =>
        {
            Utility.ValidateApiCall(HttpMethod.Get,"users/1234",req);
        }, res)),"token");

        var response = await client.Users.Get(1234);
        Assert.True(Utility.CompareJson(response, "Web_User.json", ["created_at", "updated_at"]));
    }

    [Fact]
    public async Task Presence()
    {
        var res = Utility.ExampleFileContent<PagedApiResponse<Presence[]?>>("Web_User_Presence.json")!;
        var client = (IRobinApi)new RobinClient(new HttpClient(new ActionHandler(req =>
        {
            Utility.ValidateApiCall(HttpMethod.Get, "users/1234/presence?page=2&per_page=50", req);
        }, res)), "token");

        var response = await client.Users.Presence(new GetPresenceRequest{Id=1234,Page=2,PerPage=50});
        Assert.True(Utility.CompareJson(response, "Web_User_Presence.json", ["arrived_at", "expired_at", "last_seen_at", "created_at", "updated_at"]));
    }
}