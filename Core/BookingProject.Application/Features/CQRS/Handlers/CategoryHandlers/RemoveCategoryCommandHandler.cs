using BookingProject.Application.Features.CQRS.Commands.CategoryCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }


        public async Task Handle(RemoveCategoryCommand category)
        {
            var value = await repository.GetByIdAsync(category.Id);
            await repository.RemoveAsync(value);
        }
    }
}
