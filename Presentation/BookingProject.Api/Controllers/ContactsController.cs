using BookingProject.Application.Features.CQRS.Commands.AboutCommands;
using BookingProject.Application.Features.CQRS.Commands.ContactCommands;
using BookingProject.Application.Features.CQRS.Handlers.ContactHandlers;
using BookingProject.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler createCommandHandler;
        private readonly GetContactByIdQueryHandler getContactByIdQueryHandler;
        private readonly GetContactQueryHandler getContactQueryHandler;
        private readonly RemoveContactCommandHandler removeContactCommandHandler;
        private readonly UpdateContactCommandHandler updateContactCommandHandler;

        public ContactsController(CreateContactCommandHandler createCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler, RemoveContactCommandHandler removeContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler)
        {
            this.createCommandHandler = createCommandHandler;
            this.getContactByIdQueryHandler = getContactByIdQueryHandler;
            this.getContactQueryHandler = getContactQueryHandler;
            this.removeContactCommandHandler = removeContactCommandHandler;
            this.updateContactCommandHandler = updateContactCommandHandler;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = getContactQueryHandler.Handle();
            return Ok(values);

        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var value = getContactByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await createCommandHandler.Handle(command);
            return Ok("Veriler eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await updateContactCommandHandler.Handle(command);
            return Ok("Veriler güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(RemoveContactCommand command)
        {
            await removeContactCommandHandler.Handle(new RemoveContactCommand(command.Id));
            return Ok("Veriler Silindi.");
        }
    }
}