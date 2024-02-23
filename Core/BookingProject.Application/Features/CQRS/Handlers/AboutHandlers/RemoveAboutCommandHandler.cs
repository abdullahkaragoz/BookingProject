using BookingProject.Application.Features.CQRS.Commands.AboutCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> repository;

        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveAboutCommand command)
        {
            var value = await repository.GetByIdAsync(command.Id);
            await repository.RemoveAsync(value);
        }
    }
}
