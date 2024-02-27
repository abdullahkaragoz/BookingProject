using BookingProject.Application.Features.CQRS.Results.ContactResults;
using BookingProject.Application.Interfaces;
using BookingProject.Domain.Entities;

namespace BookingProject.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
                ContactID = x.ContactID,
                Mail = x.Mail,
                MessageContent = x.MessageContent,
                NameSurname = x.NameSurname,
                SendDate = x.SendDate,
                Subject = x.Subject
            }).ToList();
        }

    }
}
