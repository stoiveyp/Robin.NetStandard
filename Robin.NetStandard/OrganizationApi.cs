using Robin.NetStandard.Entities;

namespace Robin.NetStandard;

public class OrganizationApi : IOrganizationApi
{
    public IRobinClient Client { get; set; }

    public OrganizationApi(IRobinClient client)
    {
        Client = client;
    }

    public Task<ApiResponse<Organization?>?> Get(int id)
    {
        return Client.MakeJsonCall<ApiResponse<Organization?>>(HttpMethod.Get, $"organizations/{id}");
    }

    public Task<PagedApiResponse<Location[]?>?> GetLocations(int orgId, string? query = null, int? page = null, int? perPage = null)
    {
        var prms = new Dictionary<string, string>();
        prms.AddIfNotEmpty(nameof(query), query);
        prms.AddIfNotEmpty(nameof(page), page?.ToString());
        prms.AddIfNotEmpty("per_page", perPage?.ToString());
        return Client.MakeJsonCall<PagedApiResponse<Location[]?>>(HttpMethod.Get, $"organizations/{orgId}/locations", prms);
    }

    public Task<PagedApiResponse<User[]?>?> GetUsers(int orgId, string? query = null, int? page = null, int? perPage = null, string[]? ids = null)
    {
        var prms = new Dictionary<string, string>();
        prms.AddIfNotEmpty(nameof(query), query);
        prms.AddIfNotEmpty(nameof(page), page?.ToString());
        prms.AddIfNotEmpty("per_page", perPage?.ToString());
        if (ids?.Any() ?? false)
        {
            prms.Add(nameof(ids), string.Join(",", ids));
        }

        return Client.MakeJsonCall<PagedApiResponse<User[]?>>(HttpMethod.Get, $"organizations/{orgId}/users", prms);
    }
}