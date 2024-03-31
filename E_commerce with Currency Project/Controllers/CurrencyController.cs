using E_commerce_System_currency.CachingServices;
using E_commerce_System_currency.Services.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_System_currency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IRedisCacheService _redisCacheService;
        private readonly IConfiguration _configuration;

        public CurrencyController(IRedisCacheService redisCacheService,IConfiguration configuration)
        {
            _redisCacheService = redisCacheService;
            _configuration = configuration;
        }

        #region Set Exchange Rate With redis cache
        [HttpPost("exchange-rate")]
        public IActionResult SetExchangeRate(ExchangeRateDTO exchangeRate)
        {
            // Use basic currency from configuration if exchange rate is not provided
            if (exchangeRate.CurrencyCode == _configuration["BasicCurrency"])
            {
                return BadRequest("Cannot set exchange rate for basic currency.");
            }

            _redisCacheService.SetExchangeRate(exchangeRate.CurrencyCode, exchangeRate.ExchangeRate);
            return Ok();
        }
        #endregion

        #region Get ExchangeRate for specific currencycode by redis cache
        [HttpGet("exchange-rate")]
        public IActionResult GetExchangeRate([FromQuery] string currencyCode)
        {
            var exchangeRate = _redisCacheService.GetExchangeRate(currencyCode);
            return Ok(exchangeRate);
        }
        #endregion
    }
}

