namespace Robin.NetStandard;

public interface IRobinApi
{
    IAuthApi Auth { get; }
    IOrganizationsApi Organizations { get; }
    IReservationsApi Reservations { get; }
    ISpacesApi Spaces { get; }
    IUsersApi Users { get; }
}