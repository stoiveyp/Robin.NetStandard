using Robin.NetStandard.Entities;
using Slack.NetStandard.Tests;

namespace Robin.NetStandard.Tests;

public class WebSpace
{
    [Fact]
    public async Task GetSeats()
    {
        var res = Utility.ExampleFileContent<PagedApiResponse<Space[]?>?>("Web_Space_Seats.json")!;
        var client =
            (IRobinApi)new RobinClient(
                new HttpClient(
                    new ActionHandler(req => { Utility.ValidateApiCall(HttpMethod.Get, "spaces/101/seats?page=1&per_page=50", req); },
                        res)), "token");

        var response = await client.Space.GetSeats(101, new PagedRequest{Page=1,PerPage=50});
        Assert.True(Utility.CompareJson(response, "Web_Space_Seats.json", ["created_at", "updated_at", "disabled_at"]));
    }
}