using Robin.NetStandard.Entities;

namespace Robin.NetStandard;

public interface ISpacesApi
{
    public Task<PagedApiResponse<Seat[]?>?> GetSeats(int spaceId, PagedRequest? paging);
}