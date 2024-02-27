using BookingProject.Application.Features.CQRS.Commands.CarCommands;
using BookingProject.Application.Features.CQRS.Handlers.CarHandlers;
using BookingProject.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BookingProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler createCarCommandHandler;
        private readonly GetCarByIdQueryHandler getCarByIdQueryHandler;
        private readonly GetCarQueryHandler getCarQueryHandler;
        private readonly UpdateCarCommandHandler updateCarCommandHandler;
        private readonly RemoveCarCommandHandler removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler getCarWithBrandQueryHandler;

        public CarsController(CreateCarCommandHandler createCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            this.createCarCommandHandler = createCarCommandHandler;
            this.getCarByIdQueryHandler = getCarByIdQueryHandler;
            this.getCarQueryHandler = getCarQueryHandler;
            this.updateCarCommandHandler = updateCarCommandHandler;
            this.removeCarCommandHandler = removeCarCommandHandler;
            this.getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }

        [HttpGet]
        public IActionResult CarList()
        {
            var values = getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var value = getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await createCarCommandHandler.Handle(command);
            return Ok("Veriler eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await updateCarCommandHandler.Handle(command);
            return Ok("Veriler güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(RemoveCarCommand command)
        {
            await removeCarCommandHandler.Handle(new RemoveCarCommand(command.Id));
            return Ok("Veri silindi.");
        }

        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var values = await getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
    }
}
