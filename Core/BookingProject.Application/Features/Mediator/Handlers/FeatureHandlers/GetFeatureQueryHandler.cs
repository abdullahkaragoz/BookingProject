using BookingProject.Application.Features.Mediator.Queries.FeatureQueries;
using BookingProject.Application.Features.Mediator.Results.FeatureResults;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;
using MediatR;

namespace BookingProject.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        { 
            this.repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetFeatureQueryResult
            {
                FeatureID = x.FeatureID,
                FeatureName = x.FeatureName
            }).ToList();
        }
    }
}