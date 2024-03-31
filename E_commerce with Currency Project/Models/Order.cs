using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_System_currency.Models
{
    public class Order
    {

        [Key]
        public int Id { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public string status { get; set; }

        public DateTime? ClosedOn { get; set; } 

        public string DiscountPromoCode { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal TotalPrice { get; set; }

        public string CustomerId { get; set; }

        public string CurrencyCode { get; set; }

        public decimal ExchangeRate { get; set; }

        public decimal ForignPrice { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Order_details> Order_details { get; set; }

        public virtual ICollection<Item> Items { get; set; }


  }
}
