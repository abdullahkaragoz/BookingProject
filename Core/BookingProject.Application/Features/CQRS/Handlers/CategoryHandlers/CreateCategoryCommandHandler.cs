using BookingProject.Application.Features.CQRS.Commands.CategoryCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            await repository.CreateAsync(new Category
            {
                Name = command.Name
            });
        }
    }
}
