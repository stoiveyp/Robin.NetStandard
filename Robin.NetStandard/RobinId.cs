using System.Text.Json.Serialization;
using Robin.NetStandard.Converters;

namespace Robin.NetStandard
{
    [JsonConverter(typeof(OrganizationIdConverter))]
    public class RobinId
    {
        public RobinId(){}

        public RobinId(int id)
        {
            Id = id;
        }

        public RobinId(string slug)
        {
            Slug = slug;
        }

        public int? Id { get; set; }

        public string? Slug { get; set; }

        public static implicit operator RobinId(int id) => new(id);
        public static implicit operator RobinId(string slug) => new(slug);
        public static implicit operator string(RobinId orgId) => orgId.ToString()!;

        public override string ToString() => GetValue()?.ToString()!;
        internal object? GetValue() => Id.HasValue ? Id.Value : Slug;
    }
}
