using Atm.Models;
using Core.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICardService cardService
            , ILogger<HomeController> logger)
        {
            _cardService = cardService;
            _logger = logger;
        }

        [HttpPost(nameof(CardNumber))]
        public async Task<IActionResult> CardNumber([FromBody]CardNumberRequestModel cardModel)
        {
            try
            {
                CardNumberResultModel resultModel = await _cardService.ValidateNumberAsync(cardModel.Number);
                return Ok(resultModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en {1}.{2}({3}): ", nameof(HomeController), nameof(CardNumber), cardModel.Number);

                return BadRequest(new CardNumberResultModel
                {
                    IsValid = false,
                    Message = "Error al consultar los datos. Intente más tarde."
                });
            }
        }

        [HttpPost(nameof(CardPin))]
        public async Task<IActionResult> CardPin([FromBody]CardPinRequestModel cardModel)
        {
            try
            {
                CardPinResultModel resultModel = await _cardService.ValidatePinAsync(cardModel.Id, cardModel.Pin);
                return Ok(resultModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en {1}.{2}({3}): ", nameof(HomeController), nameof(CardPin), cardModel.Pin);
                return BadRequest(new CardNumberResultModel
                {
                    IsValid = false,
                    Message = "Error al consultar los datos. Intente más tarde."
                });
            }
        }
    }
}
