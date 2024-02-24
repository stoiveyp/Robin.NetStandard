using Robin.NetStandard.Entities;

namespace Robin.NetStandard;

public class SpacesApi : ISpacesApi
{
    public IRobinClient Client { get; set; }

    public SpacesApi(IRobinClient client)
    {
        Client = client;
    }

    public Task<PagedApiResponse<Seat[]?>?> GetSeats(int spaceId, PagedRequest? paging)
    {
        return Client.MakeJsonCall<PagedApiResponse<Seat[]?>>(HttpMethod.Get, $"spaces/{spaceId}/seats", paging.AddPaging());
    }
}