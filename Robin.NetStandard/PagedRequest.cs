namespace Robin.NetStandard;

public class PagedRequest
{
    public int? Page { get; set; }
    public int? PerPage { get; set; }

    public Dictionary<string, string>? AddPaging(Dictionary<string, string>? existingQuery = null)
    {
        existingQuery ??= [];
        existingQuery.AddIfNotEmpty("page", Page);
        existingQuery.AddIfNotEmpty("per_page", PerPage);
        return existingQuery;
    }
}