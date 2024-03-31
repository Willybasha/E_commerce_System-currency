namespace E_commerce_System_currency.CachingServices
{
    public interface IRedisCacheService
    {
        void SetExchangeRate(string currencyCode, decimal exchangeRate);
        decimal GetExchangeRate(string currencyCode);

    }
}
