using BookingProject.Application.Features.CQRS.Commands.CarCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await repository.CreateAsync(new Car
            {
                BrandID = command.BrandID,
                Luggage = command.Luggage,
                Km = command.Km,
                Model = command.Model,
                Seat = command.Seat,
                Transmission = command.Transmission,
                ImageUrl = command.ImageUrl,
                Fuel = command.Fuel
            });
        }
    }
}
