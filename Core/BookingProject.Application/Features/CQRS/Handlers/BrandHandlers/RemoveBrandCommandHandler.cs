using BookingProject.Application.Features.CQRS.Commands.BrandCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> repository;

        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveBrandCommand command)
        {
            var values = await repository.GetByIdAsync(command.Id);
            await repository.RemoveAsync(values);
        }
    }
}
