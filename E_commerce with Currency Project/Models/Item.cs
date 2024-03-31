using System.ComponentModel.DataAnnotations;

namespace E_commerce_System_currency.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string ItemName { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int UOMeasureId { get; set; }
        public virtual UOMeasure UOMeasure { get; set; }

        public virtual ICollection<Order_details> Order_details { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
