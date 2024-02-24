using Robin.NetStandard.Entities;
using Robin.NetStandard.Organizations;

namespace Robin.NetStandard;

public interface IOrganizationsApi
{
    Task<ApiResponse<Entities.Organization?>?> Get(RobinId orgId);
    Task<PagedApiResponse<Location[]?>?> GetLocations(RobinId orgId);
    Task<PagedApiResponse<Location[]?>?> GetLocations(GetLocationRequest request);
    Task<PagedApiResponse<User[]?>?> GetUsers(RobinId orgId);
    Task<PagedApiResponse<User[]?>?> GetUsers(GetUsersRequest request);
    Task<ApiResponse<User?>?> GetUser(RobinId orgId, int userId);
    Task<PagedApiResponse<Amenity[]?>?> GetAmenities(RobinId orgId);
    Task<PagedApiResponse<Amenity[]?>?> GetAmenities(GetAmenitiesRequest request);
}