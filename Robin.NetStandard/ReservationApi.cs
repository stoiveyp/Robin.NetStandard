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

    public Task<PagedApiResponse<Reservation[]?>?> Get(GetReservationRequest? request)
    {
        Dictionary<string,string>? dict = null;

        if (request != null)
        {
            dict = [];
            if (request.LevelIds?.Any() ?? false)
            {
                dict.Add("level_ids", string.Join(',', request.LevelIds));
            }

            if (request.Before.HasValue)
            {
                dict.Add("before", request.Before.Value.ToString(DateTimeOffsetParseConverter.ToStringFormat));
            }

            if (request.After.HasValue)
            {
                dict.Add("after", request.After.Value.ToString(DateTimeOffsetParseConverter.ToStringFormat));
            }

            dict.AddIfNotEmpty("page",request.Page?.ToString());
            dict.AddIfNotEmpty("per_page",request.PerPage?.ToString());
        }

        return Client.MakeJsonCall<PagedApiResponse<Reservation[]?>>(HttpMethod.Get, $"reservations/seats", dict);
    }
}