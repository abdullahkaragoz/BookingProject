using BookingProject.Application.Features.CQRS.Commands.ContactCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var values = await repository.GetByIdAsync(command.ContactID);
            await   repository.UpdateAsync(values);
        }

    }
}
