using BookingProject.Application.Features.Mediator.Commands;
using BookingProject.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator mediator;

        public FeaturesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var values = await mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok("Veriler eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok("Özellik güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(RemoveFeatureCommand command)
        {
            await mediator.Send(command.Id);
            return Ok("Kayır silindi.");
        }
    }
}
