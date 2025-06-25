using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Modules.Reservations.FindMany;

public class FindManyReservationsMapper : Profile
{
    public FindManyReservationsMapper()
    {
        CreateMap<Reservation, FindManyReservationsResponse>()
            .ForMember(dest => dest.ReservedBy, opt => opt.MapFrom(src => src.ReservedBy.Username));
    }
}
