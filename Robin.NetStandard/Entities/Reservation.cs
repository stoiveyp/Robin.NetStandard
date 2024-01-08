using Robin.NetStandard.Converters;
using System.Text.Json.Serialization;

namespace Robin.NetStandard.Entities
{
    public class Reservation
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("group_seat_reservation_id")]
        public string GroupSeatReservationId { get; set; }

        [JsonPropertyName("seat_id")]
        public long SeatId { get; set; }

        [JsonPropertyName("reserver_id")]
        public long ReserverId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("start")]
        public DateTimeZone Start { get; set; }

        [JsonPropertyName("end")]
        public DateTimeZone End { get; set; }

        [JsonPropertyName("recurrence")]
        public string Recurrence { get; set; }

        [JsonPropertyName("series_id")]
        public string SeriesId { get; set; }

        [JsonPropertyName("recurrence_id")]
        public string RecurrenceId { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetParseConverter))]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonPropertyName("reservee")]
        public Reservee Reservee { get; set; }

        [JsonPropertyName("confirmation")]
        public Confirmation Confirmation { get; set; }
    }
}