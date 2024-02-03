namespace Robin.NetStandard.Reservations
{
    public class GetReservationRequest
    {
        public List<string> LevelIds { get; set; } = new();
        public DateTimeOffset? Before { get; set; }
        public DateTimeOffset? After { get; set; }
        public int? Page { get; set; }
        public int? PerPage { get; set; }
    }
}
