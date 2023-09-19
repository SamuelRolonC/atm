using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Atm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaintenanceController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly ILogger<MaintenanceController> _logger;

        public MaintenanceController(ICardService cardService
            , ILogger<MaintenanceController> logger)
        {
            _cardService = cardService;
            _logger = logger;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet(nameof(Hash))]
        public async Task<IActionResult> Hash()
        {
            try
            {
                await _cardService.SetHashField();
                return Ok("Success");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en {1}.{2}(): ", nameof(MaintenanceController), nameof(Hash));
                return BadRequest("Error");
            }
        }
    }
}
