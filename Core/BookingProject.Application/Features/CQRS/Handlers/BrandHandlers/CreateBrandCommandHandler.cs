using BookingProject.Application.Features.CQRS.Commands.BrandCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> repository;

        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateBrandCommand command)
        {
            await repository.CreateAsync(new Brand
            {
                BrandName = command.BrandName
            });
        }
    }
}
