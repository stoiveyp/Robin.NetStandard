using Robin.NetStandard.Entities;
using Robin.NetStandard.Organizations;

namespace Robin.NetStandard;

public class OrganizationApi : IOrganizationApi
{
    public IRobinClient Client { get; set; }

    public OrganizationApi(IRobinClient client)
    {
        Client = client;
    }

    public Task<ApiResponse<Organization?>?> Get(OrganizationId slug)
    {
        return Client.MakeJsonCall<ApiResponse<Organization?>>(HttpMethod.Get, $"organizations/{slug}");
    }

    public Task<PagedApiResponse<Location[]?>?> GetLocations(OrganizationId orgId) =>
        GetLocations(new GetLocationRequest { Id = orgId });

    public Task<PagedApiResponse<Location[]?>?> GetLocations(GetLocationRequest request)
    {
        var prms = new Dictionary<string, string>();
        prms.AddIfNotEmpty("query", request.Query);
        prms.AddIfNotEmpty("page", request.Page?.ToString());
        prms.AddIfNotEmpty("per_page", request.PerPage?.ToString());
        return Client.MakeJsonCall<PagedApiResponse<Location[]?>>(HttpMethod.Get, $"organizations/{request.Id}/locations", prms);

    }

    public Task<PagedApiResponse<User[]?>?> GetUsers(OrganizationId orgId) =>
        GetUsers(new GetUsersRequest { Id = orgId });

    public Task<PagedApiResponse<User[]?>?> GetUsers(GetUsersRequest request)
    {
        var prms = new Dictionary<string, string>();
        prms.AddIfNotEmpty("query", request.Query);
        prms.AddIfNotEmpty("page",request.Page?.ToString());
        prms.AddIfNotEmpty("per_page", request.PerPage?.ToString());
        if (request.Ids?.Any() ?? false)
        {
            prms.Add("ids", string.Join(",", request.Ids));
        }

        return Client.MakeJsonCall<PagedApiResponse<User[]?>>(HttpMethod.Get, $"organizations/{request.Id}/users", prms);
    }
}