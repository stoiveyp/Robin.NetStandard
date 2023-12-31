
using Robin.NetStandard.Entities;

namespace Robin.NetStandard;

public interface IOrganizationApi
{
    Task<ApiResponse<Organization?>?> Get(int id);
    Task<PagedApiResponse<Location[]?>?> GetLocations(int orgId, string? query = null, int? page = null, int? perPage = null);
    Task<PagedApiResponse<User[]?>?> GetUsers(int orgId, string? query = null, int? page = null, int? perPage = null, string[]? ids = null);
}