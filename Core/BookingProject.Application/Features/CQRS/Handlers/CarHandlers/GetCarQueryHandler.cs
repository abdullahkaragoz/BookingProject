using BookingProject.Application.Features.CQRS.Results.CarResults;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x=> new GetCarQueryResult
            {
                BrandID = x.BrandID,
                ImageUrl = x.ImageUrl,
                CarID = x.CarID,
                Fuel = x.Fuel,
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
