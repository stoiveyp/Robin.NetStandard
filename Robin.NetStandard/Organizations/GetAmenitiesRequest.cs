namespace Robin.NetStandard.Organizations;

public class GetAmenitiesRequest : PagedRequest
{
    public OrganizationId Id { get; set; }
}