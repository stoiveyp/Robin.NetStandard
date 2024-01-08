using Robin.NetStandard.Converters;
using Robin.NetStandard.Entities;
using Robin.NetStandard.Reservations;

namespace Robin.NetStandard;

public class ReservationApi : IReservationApi
{
    public IRobinClient Client { get; set; }

    public ReservationApi(IRobinClient client)
    {
        Client = client;
    }

    public Task<PagedApiResponse<Reservation[]?>?> Search(ReservationSearchRequest request)
    {
        var dict = new Dictionary<string, string>();
        if (request.LevelIds?.Any() ?? false)
        {
            dict.Add("level_ids",string.Join(',',request.LevelIds));
        }

        if (request.Before.HasValue)
        {
            dict.Add("before", request.Before.Value.ToString(DateTimeOffsetParseConverter.ToStringFormat));
        }

        if (request.After.HasValue)
        {
            dict.Add("after", request.After.Value.ToString(DateTimeOffsetParseConverter.ToStringFormat));
        }

        return Client.MakeJsonCall<PagedApiResponse<Reservation[]?>>(HttpMethod.Get, $"reservations/seats", dict);
    }
}