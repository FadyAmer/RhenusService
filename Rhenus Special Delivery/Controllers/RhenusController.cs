using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rhenus_Special_Delivery.DataAccess;
using Rhenus_Special_Delivery.Services;
using Rhenus_Special_Delivery.DTOs;

namespace Rhenus_Special_Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RhenusController : ControllerBase
    {
        private readonly IRhenusService _gameService;

        public RhenusController(IRhenusService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("bet")]
        public IActionResult PlaceBet(BetRequest betRequest, [FromHeader] string playerId)
        {
            BetResponse response;
            try
            {
                response = _gameService.PlaceBet(betRequest, playerId);
            }
            catch (ArgumentException e)
            {
                return BadRequest("Validation Error: "+e.Message);
            }
            return Ok(response);
        }

        
    }
}
