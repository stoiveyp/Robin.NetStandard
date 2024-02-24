using Robin.NetStandard.Entities;
using Robin.NetStandard.Users;

namespace Robin.NetStandard;

public class UsersApi:IUsersApi{

    public IRobinClient Client { get; set; }

    public UsersApi(IRobinClient client)
    {
        Client = client;
    }

    public Task<ApiResponse<User?>?> Get(RobinId userId)
    {
        return Client.MakeJsonCall<ApiResponse<User?>>(HttpMethod.Get, $"users/{userId}");
    }

    public Task<PagedApiResponse<Presence[]?>?> Presence(RobinId userId)
    {
        throw new NotImplementedException();
    }

    public Task<PagedApiResponse<Presence[]?>?> Presence(GetPresenceRequest userId)
    {
        throw new NotImplementedException();
    }
}