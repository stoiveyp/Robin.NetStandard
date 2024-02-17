namespace Robin.NetStandard.Organizations;

public class GetUsersRequest:PagedRequest
{
    public OrganizationId Id { get; set; }
    public string? Query { get; set; }
    public List<string> Ids = new ();
}