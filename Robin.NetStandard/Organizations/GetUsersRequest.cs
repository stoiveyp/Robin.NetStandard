namespace Robin.NetStandard.Organizations;

public class GetUsersRequest:PagedRequest
{
    public RobinId Id { get; set; }
    public string? Query { get; set; }
    public List<string> Ids = new ();
}