namespace BookingProject.Application.Features.CQRS.Queries
{
    public class GetAboutByIdQuery
    {
        public int Id { get; set; }
        public GetAboutByIdQuery(int id)
        {
            Id = id;
        }

    }
}
