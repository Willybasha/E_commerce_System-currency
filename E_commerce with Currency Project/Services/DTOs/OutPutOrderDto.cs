namespace E_commerce_System_currency.Services.DTOs
{
    public class OutPutOrderDto
    {
        public int id { get; set; }
        public DateTime RequestDate { get; set; }

        public DateTime ClosedDate { get; set; }

        public string status { get; set; }

        public string CustomerId { get; set; }
        public string DiscountPromoCode { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal TotalPrice { get; set; }

        public string CurrencyCode{ get; set; }

        public decimal ExchangeRate { get; set; }

        public decimal ForignPrice { get; set; }
    }
}
