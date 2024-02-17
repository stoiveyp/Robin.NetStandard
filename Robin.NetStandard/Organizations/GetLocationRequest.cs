namespace Robin.NetStandard.Organizations
{
    public class GetLocationRequest:PagedRequest
    {
        public OrganizationId Id { get; set; }
        public string? Query { get; set; }
    }
}
