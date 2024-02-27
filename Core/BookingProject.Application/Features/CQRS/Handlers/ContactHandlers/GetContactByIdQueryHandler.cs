using BookingProject.Application.Features.CQRS.Queries.CarQueries;
using BookingProject.Application.Features.CQRS.Results.ContactResults;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactID = values.ContactID,
                Mail = values.Mail,
                MessageContent = values.MessageContent,
                NameSurname = values.NameSurname,
                SendDate = values.SendDate,
                Subject = values.Subject
            };
        }
    }
}
