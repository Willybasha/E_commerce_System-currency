using System.ComponentModel.DataAnnotations;

namespace E_commerce_System_currency.Services.DTOs
{
    public class UpdateItemDto
    {

        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string itemName { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int UOMeasureId { get; set; }


    }
}
