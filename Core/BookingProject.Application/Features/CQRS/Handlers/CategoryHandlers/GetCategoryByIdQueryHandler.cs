using BookingProject.Application.Features.CQRS.Queries.CategoryQueries;
using BookingProject.Application.Features.CQRS.Results.CategoryResults;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<GetCategoryQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var values = await repository.GetByIdAsync(query.Id);
            return new GetCategoryQueryResult
            {
                CategoryID = values.CategoryID,
                Name = values.Name
            };
        }
    }
}
