using BookingProject.Application.Features.Mediator.Commands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;
using MediatR;

namespace BookingProject.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> repository;

        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Feature
            {
                FeatureName = request.FeatureName
            });
        }

    }
}
