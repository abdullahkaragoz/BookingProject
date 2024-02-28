using BookingProject.Application.Features.Mediator.Commands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;
using MediatR;

namespace BookingProject.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
    {
        private readonly IRepository<Feature> repository;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(value);
        }

    }
}
