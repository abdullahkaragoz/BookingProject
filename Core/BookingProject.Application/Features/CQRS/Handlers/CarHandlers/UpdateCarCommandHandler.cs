using BookingProject.Application.Features.CQRS.Commands.CarCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var values = await repository.GetByIdAsync(command.BrandID);
            await repository.UpdateAsync(values);
        }

    }
}
