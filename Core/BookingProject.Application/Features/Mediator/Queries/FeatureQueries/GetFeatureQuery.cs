using BookingProject.Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace BookingProject.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
    {

    }
}
