using BookingProject.Application.Features.CQRS.Commands.BannerCommands;
using BookingProject.Application.Features.CQRS.Handlers.BannerHandlers;
using BookingProject.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler createBannerCommandHandler;
        private readonly GetBannerByIdQueryHandler getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler getBannerQueryHandler;
        private readonly RemoveBannerCommandHandler removeBannerCommandHandler;
        private readonly UpdateBannerCommandHandler updateBannerCommandHandler;

        public BannersController(CreateBannerCommandHandler createBannerCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, RemoveBannerCommandHandler removeBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler)
        {
            this.createBannerCommandHandler = createBannerCommandHandler;
            this.getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            this.getBannerQueryHandler = getBannerQueryHandler;
            this.removeBannerCommandHandler = removeBannerCommandHandler;
            this.updateBannerCommandHandler = updateBannerCommandHandler;
        }

        [HttpGet]
        public IActionResult BannerList()
        {
            var values = getBannerQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetBanner(int id)
        {
            var value = getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await createBannerCommandHandler.Handle(command);
            return Ok("Veriler eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Veri silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await updateBannerCommandHandler.Handle(command);
            return Ok("Veri güncellendi");
        }

    }
}
