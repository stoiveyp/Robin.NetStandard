using Robin.NetStandard.Entities;
using Slack.NetStandard.Tests;

namespace Robin.NetStandard.Tests;

public class WebOrg
{
    [Fact]
    public async Task GetById()
    {
        var res = Utility.ExampleFileContent<ApiResponse<Organization?>?>("Web_Org.json")!;
        var client =
            (IRobinApi)new RobinClient(
                new HttpClient(
                    new ActionHandler(req => { Utility.ValidateApiCall(HttpMethod.Get, "organizations/34", req); },
                        res)), "token");

        var response = await client.Organization.Get(34);
        Assert.True(Utility.CompareJson(response, "Web_Org.json", ["created_at", "updated_at"]));
    }

    [Fact]
    public async Task GetLocations()
    {
        var res = Utility.ExampleFileContent<PagedApiResponse<Location[]?>?>("Web_Org_Location.json")!;
        var client =
            (IRobinApi)new RobinClient(
                new HttpClient(new ActionHandler(
                    req =>
                    {
                        Utility.ValidateApiCall(HttpMethod.Get,
                            "organizations/34/locations?query=not&page=2&per_page=2", req);
                    }, res)), "token");

        var response = await client.Organization.GetLocations(34, perPage: 2, query: "not", page: 2);
        Assert.True(Utility.CompareJson(response, "Web_Org_Location.json", ["created_at", "updated_at"]));
    }

    [Fact]
    public async Task GetUsers()
    {
        var res = Utility.ExampleFileContent<PagedApiResponse<User[]?>?>("Web_Org_Users.json")!;
        var client =
            (IRobinApi)new RobinClient(
                new HttpClient(new ActionHandler(
                    req =>
                    {
                        Utility.ValidateApiCall(HttpMethod.Get,
                            "organizations/34/users?query=not&page=2&per_page=2&ids=1%2c2%2c3", req);
                    }, res)), "token");

        var response = await client.Organization.GetUsers(34, perPage: 2, query: "not", ids:["1","2","3"],page: 2);
        Assert.True(Utility.CompareJson(response, "Web_Org_Users.json", ["created_at", "updated_at"]));
    }
}