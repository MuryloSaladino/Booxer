using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Commands.Reservations.Create;

public class CreateCategoryMapper : Profile
{
    public CreateCategoryMapper()
    {
        CreateMap<CreateReservationRequest, Reservation>();
        CreateMap<Reservation, CreateReservationResponse>();
    }
}
