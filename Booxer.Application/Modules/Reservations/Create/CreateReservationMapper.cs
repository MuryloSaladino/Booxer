using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Modules.Reservations.Create;

public class CreateCategoryMapper : Profile
{
    public CreateCategoryMapper()
    {
        CreateMap<CreateReservationRequest, Reservation>();
        CreateMap<Reservation, CreateReservationResponse>();
    }
}
