using Robin.NetStandard.Entities;
using Robin.NetStandard.Reservations;
using Slack.NetStandard.Tests;

namespace Robin.NetStandard.Tests;

public class WebReservation
{
    [Fact]
    public async Task Search()
    {
        var res = Utility.ExampleFileContent<PagedApiResponse<Reservation[]?>?>("Web_Org_Reservation.json")!;
        var client =
            (IRobinApi)new RobinClient(
                new HttpClient(
                    new ActionHandler(req => { Utility.ValidateApiCall(HttpMethod.Get, "reservations/seats?level_ids=103864", req); },
                        res)), "token");

        var response = await client.Reservation.Search(new ReservationSearchRequest{ LevelIds = ["103864"] });
        Assert.True(Utility.CompareJson(response, "Web_Org_Reservation.json", ["created_at", "updated_at", "date_time"]));
    }
}