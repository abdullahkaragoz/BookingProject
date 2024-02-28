using BookingProject.Application.Features.Mediator.Commands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;
using MediatR;

namespace BookingProject.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var values = await repository.GetByIdAsync(request.FeatureID);
            values.FeatureName = request.FeatureName;
            await repository.UpdateAsync(values);
        }

       
    }
}
