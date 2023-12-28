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
        return Client.MakeJsonCall<Organization?>(HttpMethod.Get, $"/organizations/{id}");
    }
}