using MediatR;

namespace BookingProject.Application.Features.Mediator.Commands
{
    public class CreateFeatureCommand : IRequest
    {
        public string FeatureName { get; set; }
    }
}
