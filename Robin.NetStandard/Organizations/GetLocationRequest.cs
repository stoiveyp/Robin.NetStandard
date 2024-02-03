namespace Robin.NetStandard.Organizations
{
    public class GetLocationRequest
    {
        public OrganizationId Id { get; set; }
        public string? Query { get; set; }
        public int? Page { get; set; }
        public int? PerPage { get; set; }
    }

    public class GetUsersRequest
    {
        public OrganizationId Id { get; set; }
        public string? Query { get; set; }
        public int? Page { get; set; }
        public int? PerPage { get; set; }
        public List<string> Ids = new ();
    }
}
