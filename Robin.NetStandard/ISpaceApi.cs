using Robin.NetStandard.Entities;

namespace Robin.NetStandard;

public interface ISpaceApi
{
    public Task<PagedApiResponse<Seat[]?>?> GetSeats(int spaceId, PagedRequest? paging);
}