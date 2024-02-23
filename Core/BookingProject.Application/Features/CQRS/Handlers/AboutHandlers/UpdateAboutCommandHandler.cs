using BookingProject.Application.Features.CQRS.Commands.AboutCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }

        public async Task Handle (UpdateAboutCommand command)
        {
            var values = await repository.GetByIdAsync(command.AboutID);
            values.Description = command.Description;
            values.Title = command.Title;
            values.ImageUrl = command.ImageUrl;
            await repository.UpdateAsync(values);
        }
    }
}
