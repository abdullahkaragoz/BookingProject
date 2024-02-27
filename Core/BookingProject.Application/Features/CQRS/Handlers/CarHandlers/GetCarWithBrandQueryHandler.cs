using BookingProject.Application.Features.CQRS.Results.CarResults;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly IRepository<Car> repository;

        public GetCarWithBrandQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandID = x.BrandID,
                BrandName = x.Brand.BrandName,
                CarID = x.CarID,
                Fuel = x.Fuel,
                ImageUrl = x.ImageUrl,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission,
                Year = x.Year
            }).ToList();
        }
    }
}
