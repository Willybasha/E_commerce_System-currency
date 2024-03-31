using StackExchange.Redis;

namespace E_commerce_System_currency.CachingServices
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDatabase _database;
        private readonly IConfiguration _configuration;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer, IConfiguration configuration)
        {
            _database = connectionMultiplexer.GetDatabase();
            _configuration = configuration;
        }

        public void SetExchangeRate(string currencyCode, decimal exchangeRate)
        {
            var expirationTime = TimeSpan.FromMinutes(_configuration.GetValue<int>("Redis:ExpirationTimeMinutes"));
            _database.StringSet(currencyCode, exchangeRate.ToString(), expirationTime);
        }

        public decimal GetExchangeRate(string currencyCode)
        {
            var exchangeRate = _database.StringGet(currencyCode);
            return exchangeRate.HasValue ? (decimal)exchangeRate : 0;
        }
    }
}
