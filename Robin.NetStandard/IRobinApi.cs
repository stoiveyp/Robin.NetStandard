namespace Robin.NetStandard;

public interface IRobinApi
{
    IAuthApi Auth { get; }
    IOrganizationApi Organization { get; }
    IReservationApi Reservation { get; }
}