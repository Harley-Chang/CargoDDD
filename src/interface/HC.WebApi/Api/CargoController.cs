using HC.Domain.CargoAggregate.Command;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace HC.WebApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CargoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task BookingCargoAsync(BookCargoCommand command)
        {
            await _mediator.Publish(command);
        }

        [HttpGet]
        public async Task<string> GetAsync()
        {
            return await Task.FromResult(DateTime.Now.Year.ToString());
        }
    }
}
