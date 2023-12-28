
using Robin.NetStandard.Entities;

namespace Robin.NetStandard;

public interface IOrganizationApi
{
    Task<ApiResponse<Organization?>?> Get(int id);
}