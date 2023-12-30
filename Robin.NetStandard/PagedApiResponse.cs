using System.Text.Json.Serialization;

namespace Robin.NetStandard;

public class PagedApiResponse<T>:ApiResponse<T>
{
    [JsonPropertyName("paging")]
    public Paging? Paging { get; set; }
}