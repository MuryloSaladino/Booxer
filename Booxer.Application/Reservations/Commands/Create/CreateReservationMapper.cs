using AutoMapper;
using Booxer.Domain.Entities;

namespace Booxer.Application.Reservations.Commands.Create;

public class CreateCategoryMapper : Profile
{
    public CreateCategoryMapper()
    {
        CreateMap<CreateReservationRequest, Reservation>();
        CreateMap<Reservation, CreateReservationResponse>();
    }
}
