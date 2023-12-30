using Robin.NetStandard.Auth;

namespace Robin.NetStandard;

public interface IAuthApi
{
    Task<ApiResponse<AuthData?>?> TokenInfo();
}