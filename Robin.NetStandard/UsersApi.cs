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

    public Task<PagedApiResponse<Presence[]?>?> Presence(RobinId userId) => Presence(new GetPresenceRequest { Id = userId });

    public Task<PagedApiResponse<Presence[]?>?> Presence(GetPresenceRequest request)
    {
        return Client.MakeJsonCall<PagedApiResponse<Presence[]?>?>(HttpMethod.Get,$"users/{request.Id}/presence", request.AddPaging());
    }
}