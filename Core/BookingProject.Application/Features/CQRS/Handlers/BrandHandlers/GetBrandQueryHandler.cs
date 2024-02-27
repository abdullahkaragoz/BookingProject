using BookingProject.Application.Features.CQRS.Results.BrandResults;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> repository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetBrandQueryResult
            {
                BrandID = x.BrandID,
                BrandName = x.BrandName
            }).ToList();
        }
    }
}
