using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Reservations.Commands.FindMany;

public class FindManyReservationsMapper : Profile
{
    public FindManyReservationsMapper()
    {
        CreateMap<Reservation, FindManyReservationsResponse>()
            .ForCtorParam("ReservedBy", opt => opt.MapFrom(src => src.ReservedBy.Username));
    }
}
