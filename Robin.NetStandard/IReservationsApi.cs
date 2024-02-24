using Robin.NetStandard.Entities;
using Robin.NetStandard.Reservations;

namespace Robin.NetStandard;

public interface IReservationsApi
{
    Task<PagedApiResponse<Reservation[]?>?> Get(GetReservationRequest? request);
}