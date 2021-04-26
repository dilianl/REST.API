using System;
using System.Threading.Tasks;
using Calculate.Api.BusinessLogic.Interfaces;
using Calculate.Api.Dto.Api;
using Calculate.Api.ErrorHandling;
using Calculate.Api.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calculate.Api.Controllers
{
    [ApiController]
    [Route("calculate")]
    [Produces("application/json")]
    public class CalculateController : ControllerBase
    {
        private readonly ILogger<CalculateController> _logger;
        private ICalculateService _calculateService;

        public CalculateController(ICalculateService calculateService, ILogger<CalculateController> logger)
        {
            _calculateService = calculateService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> GetSum([FromBody] TwoIntNumbersDTO twoIntNumbersDTO)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            try
            {
                try
                {
                    var result = await _calculateService.Sum(twoIntNumbersDTO);

                    return this.Ok(result);
                }
                catch (ApiException aex) when (aex.ApiError != null)
                {
                    return this.HandleApiException(aex);
                }
            }
            catch (Exception e)
            {
                this._logger.LogError(e.Message);
                return this.StatusCode(500, Utility.GetExceptionMessages(e));
            }
        }

        [HttpPost]
        [Route("combination")]
        public async Task<IActionResult> GetCombination([FromBody] TwoIntNumbersDTO twoIntNumbersDTO)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            try
            {
                try
                {
                    var result = await _calculateService.Combination(twoIntNumbersDTO);

                    return this.Ok(result);
                }
                catch (ApiException aex) when (aex.ApiError != null)
                {
                    return this.HandleApiException(aex);
                }
            }
            catch (Exception e)
            {
                this._logger.LogError(e.Message);
                return this.StatusCode(500, Utility.GetExceptionMessages(e));
            }
        }

        private IActionResult HandleApiException(ApiException aex)
        {
            switch ((UserErrorType)(aex?.ApiError?.ErrorCode ?? 0))
            {
                case UserErrorType.NoContent: return this.NoContent();
                case UserErrorType.BadRequest: return this.BadRequest(aex.ApiError);
                case UserErrorType.Unauthorized: return this.StatusCode(401, aex.ApiError);
                case UserErrorType.Forbidden: return this.Forbid();
                case UserErrorType.NotFound: return this.NotFound(aex.ApiError);
                case UserErrorType.UnprocessableEntity: return this.UnprocessableEntity(aex.ApiError);
                case UserErrorType.NotImplemented: return this.StatusCode(501, aex.ApiError);

                case UserErrorType.InternalServerError: throw aex;
                default: throw new Exception($"Unknown ApiException.ApiError.ErrorCode ({aex?.ApiError?.ErrorCode.ToString() ?? "N/A"})!", aex);
            }
        }
    }
    
}
