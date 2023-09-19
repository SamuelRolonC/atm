using Core.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;
        private readonly ILogger<OperationController> _logger;

        public OperationController(IOperationService operationService
            , ILogger<OperationController> logger)
        {
            _operationService = operationService;
            _logger = logger;
        }

        [HttpGet(nameof(Balance))]
        public async Task<IActionResult> Balance(int cardId)
        {
            var resultModel = new BalanceResultModel();
            try
            {
                resultModel = await _operationService.BalanceAsync(cardId);
            }
            catch (Exception ex)
            {
                resultModel.Success = false;
                resultModel.Message = "Error al consultar los datos. Intente más tarde.";

                return BadRequest(resultModel);
            }

            if (resultModel.Success)
                return Ok(resultModel);
            else
                return BadRequest(resultModel);
        }

        [HttpGet(nameof(Withdraw))]
        public async Task<IActionResult> Withdraw(int cardId, decimal amount)
        {
            var resultModel = new WithdrawResultModel();
            try
            {
                resultModel = await _operationService.WithdrawAsync(cardId, amount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en {1}.{2}({3},{4}): ", nameof(OperationController), nameof(Withdraw), cardId, amount);
                resultModel.Success = false;
                resultModel.Message = "Error al procesar la operación. Intente más tarde.";

                return BadRequest(resultModel);
            }

            if (resultModel.Success)
                return Ok(resultModel);
            else
                return BadRequest(resultModel);
        }
    }
}
