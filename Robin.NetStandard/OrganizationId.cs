using System.Text.Json.Serialization;
using Robin.NetStandard.Converters;

namespace Robin.NetStandard
{
    [JsonConverter(typeof(OrganizationIdConverter))]
    public class OrganizationId
    {
        public OrganizationId(){}

        public OrganizationId(int id)
        {
            Id = id;
        }

        public OrganizationId(string slug)
        {
            Slug = slug;
        }

        public int? Id { get; set; }

        public string? Slug { get; set; }

        public static implicit operator OrganizationId(int id) => new(id);
        public static implicit operator OrganizationId(string slug) => new(slug);
        public static implicit operator string(OrganizationId orgId) => orgId.ToString()!;

        public override string ToString() => GetValue()?.ToString()!;
        internal object? GetValue() => Id.HasValue ? Id.Value : Slug;
    }
}
