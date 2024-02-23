using BookingProject.Application.Features.CQRS.Commands.BannerCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }

        public async Task Handler(CreateBannerCommand command)
        {
            await repository.CreateAsync(new Banner
            {
                Title = command.Title,
                Description = command.Description,
                VideoDescription = command.VideoDescription,
                VideoUrl = command.VideoUrl
            });
        }
    }
}
