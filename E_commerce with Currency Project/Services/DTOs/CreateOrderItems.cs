using System.ComponentModel.DataAnnotations;

namespace E_commerce_System_currency.Services.DTOs
{
    public class CreateOrderItems
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string ItemName { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string CurrencyCode { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
