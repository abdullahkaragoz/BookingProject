using BookingProject.Application.Features.CQRS.Commands.BannerCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var values = await repository.GetByIdAsync(command.BannerID);
            values.Description = command.Description;
            values.Title = command.Title;
            values.VideoUrl = command.VideoUrl; 
            values.VideoDescription = command.VideoDescription;
            await repository.UpdateAsync(values);

        }
    }
}
