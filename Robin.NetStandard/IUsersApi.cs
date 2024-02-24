using Robin.NetStandard.Entities;
using Robin.NetStandard.Users;

namespace Robin.NetStandard
{
    public interface IUsersApi
    {
        Task<ApiResponse<User?>?> Get(RobinId userId);
        Task<PagedApiResponse<Presence[]?>?> Presence(RobinId userId);
        Task<PagedApiResponse<Presence[]?>?> Presence(GetPresenceRequest userId);
    }
}
