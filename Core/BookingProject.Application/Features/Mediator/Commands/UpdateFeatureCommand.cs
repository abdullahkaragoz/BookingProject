using MediatR;

namespace BookingProject.Application.Features.Mediator.Commands
{
    public class UpdateFeatureCommand : IRequest
    {
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
    }
}
