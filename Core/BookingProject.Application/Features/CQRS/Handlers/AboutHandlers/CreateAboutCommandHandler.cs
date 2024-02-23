using BookingProject.Application.Features.CQRS.Commands.AboutCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateAboutCommand command)
        {
            await repository.CreateAsync(new About
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl
            });
        }
    }
}
