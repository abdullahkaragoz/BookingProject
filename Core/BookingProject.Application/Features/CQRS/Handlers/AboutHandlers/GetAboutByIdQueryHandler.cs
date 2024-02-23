using BookingProject.Application.Features.CQRS.Queries;
using BookingProject.Application.Features.CQRS.Results.AboutResults;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var values = await repository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResult
            {
                AboutID = values.AboutID,
                Description = values.Description,
                ImageUrl = values.ImageUrl,
                Title = values.Title
            };
        }
    }

}