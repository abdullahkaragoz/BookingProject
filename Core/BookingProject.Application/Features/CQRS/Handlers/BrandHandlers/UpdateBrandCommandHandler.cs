using BookingProject.Application.Features.CQRS.Commands.BrandCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateBrandCommand command)
        {
            var values = await repository.GetByIdAsync(command.BrandID);
            values.BrandName = command.BrandName;
            await repository.UpdateAsync(values);
        }
    }
}
