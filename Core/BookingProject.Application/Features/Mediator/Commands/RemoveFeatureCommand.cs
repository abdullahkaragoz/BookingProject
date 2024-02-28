using MediatR;

namespace BookingProject.Application.Features.Mediator.Commands
{
    public class RemoveFeatureCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveFeatureCommand(int id)
        {
            Id = id;
        }
    }
}
