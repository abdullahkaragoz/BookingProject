using BookingProject.Application.Features.CQRS.Commands.AboutCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> repository;

        public RemoveBannerCommandHandler(IRepository<Banner> repository)
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
