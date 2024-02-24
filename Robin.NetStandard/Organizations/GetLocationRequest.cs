namespace Robin.NetStandard.Organizations
{
    public class GetLocationRequest:PagedRequest
    {
        public RobinId Id { get; set; }
        public string? Query { get; set; }
    }
}
