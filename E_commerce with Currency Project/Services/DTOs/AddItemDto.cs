using System.ComponentModel.DataAnnotations;

namespace E_commerce_System_currency.Services.DTOs
{
    public class AddItemDto
    {
        [Required, MaxLength(50)]
        public string ItemName { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int UOMeasureId { get; set; }
    }
}
