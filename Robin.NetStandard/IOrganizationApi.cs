
using Robin.NetStandard.Entities;
using Robin.NetStandard.Organizations;

namespace Robin.NetStandard;

public interface IOrganizationApi
{
    Task<ApiResponse<Organization?>?> Get(OrganizationId orgId);
    Task<PagedApiResponse<Location[]?>?> GetLocations(OrganizationId orgId);
    Task<PagedApiResponse<Location[]?>?> GetLocations(GetLocationRequest request);
    Task<PagedApiResponse<User[]?>?> GetUsers(OrganizationId orgId);
    Task<PagedApiResponse<User[]?>?> GetUsers(GetUsersRequest request);
}