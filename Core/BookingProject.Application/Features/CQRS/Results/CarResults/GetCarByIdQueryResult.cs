using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Results.CarResults
{
    public class GetCarByIdQueryResult
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public string Seat { get; set; }
        public string Luggage { get; set; }
        public string Fuel { get; set; }
    }
}
