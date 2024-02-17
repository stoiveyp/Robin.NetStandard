using Robin.NetStandard.Entities;

namespace Robin.NetStandard;

public class SpaceApi : ISpaceApi
{
    public IRobinClient Client { get; set; }

    public SpaceApi(IRobinClient client)
    {
        Client = client;
    }

    public Task<PagedApiResponse<Seat[]?>?> GetSeats(int spaceId, PagedRequest? paging)
    {
        return Client.MakeJsonCall<PagedApiResponse<Seat[]?>>(HttpMethod.Get, $"spaces/{spaceId}/seats", paging.AddPaging());
    }
}