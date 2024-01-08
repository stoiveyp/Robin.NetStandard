using System.Text.Json.Serialization;

namespace Robin.NetStandard.Reservations
{
    public class ReservationSearchRequest
    {
        public List<string> LevelIds { get; set; } = new();
    }
}
