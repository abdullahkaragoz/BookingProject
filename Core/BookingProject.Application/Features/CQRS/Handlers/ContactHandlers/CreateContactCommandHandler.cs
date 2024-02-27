using BookingProject.Application.Features.CQRS.Commands.ContactCommands;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateContactCommand command)
        {
            await repository.CreateAsync(new Contact
            {
                Mail = command.Mail,
                MessageContent = command.MessageContent,
                NameSurname = command.NameSurname,
                SendDate = command.SendDate,
                Subject = command.Subject
            });
        }
    }
}
