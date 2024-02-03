using Robin.NetStandard.Entities;
using Robin.NetStandard.Reservations;

namespace Robin.NetStandard;

public interface IReservationApi
{
    Task<PagedApiResponse<Reservation[]?>?> Get(ReservationSearchRequest? request);
}