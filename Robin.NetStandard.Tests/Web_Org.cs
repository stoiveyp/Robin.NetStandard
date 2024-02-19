using Robin.NetStandard.Entities;
using Robin.NetStandard.Organizations;
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
                    new ActionHandler(req => { Utility.ValidateApiCall(HttpMethod.Get, "organizations/test", req); },
                        res)), "token");

        var response = await client.Organization.Get("test");
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

        var request = new GetLocationRequest
        {
            Id = 34,
            PerPage = 2,
            Query = "not",
            Page = 2
        };
        var response = await client.Organization.GetLocations(request);
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


        var request = new GetUsersRequest
        {
            Id = 34,
            PerPage = 2,
            Query = "not",
            Page = 2,
            Ids = ["1", "2", "3"]
        };
        var response = await client.Organization.GetUsers(request);
        Assert.True(Utility.CompareJson(response, "Web_Org_Users.json", ["created_at", "updated_at"]));
    }

    [Fact]
    public async Task GetAmenities()
    {
        var res = Utility.ExampleFileContent<PagedApiResponse<Amenity[]?>?>("Web_Org_Amenities.json")!;
        var client =
            (IRobinApi)new RobinClient(
                new HttpClient(new ActionHandler(
                    req =>
                    {
                        Utility.ValidateApiCall(HttpMethod.Get,
                            "organizations/bjss/amenities?page=2&per_page=2", req);
                    }, res)), "token");


        var request = new GetAmenitiesRequest
        {
            Id = "bjss",
            PerPage = 2,
            Page = 2
        };
        var response = await client.Organization.GetAmenities(request);
        Assert.True(Utility.CompareJson(response, "Web_Org_Amenities.json", ["created_at", "updated_at"]));
    }
}