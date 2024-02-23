using BookingProject.Application.Features.CQRS.Results.AboutResults;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult
            {
                BannerID = x.BannerID,
                Description = x.Description,
                Title = x.Title,
                VideoDescription = x.VideoDescription,
                VideoUrl = x.VideoUrl
            }).ToList();
        }
    }
}
