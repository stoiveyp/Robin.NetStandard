using Robin.NetStandard.Auth;

namespace Robin.NetStandard;

public class AuthApi : IAuthApi
{
    public IRobinClient Client { get; }

    public AuthApi(IRobinClient client)
    {
        Client = client;
    }

    public Task<ApiResponse<AuthData>> TokenInfo()
    {
        return Client.MakeJsonCall<AuthData>(HttpMethod.Get,"auth");
    }
}