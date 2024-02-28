using BookingProject.Application.Features.Mediator.Queries.FeatureQueries;
using BookingProject.Application.Features.Mediator.Results.FeatureResults;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;
using MediatR;

namespace BookingProject.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            this.repository = repository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResult
            {
                FeatureID = values.FeatureID,
                FeatureName = values.FeatureName
            };
        }
    }
}
