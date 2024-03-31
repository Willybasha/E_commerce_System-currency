namespace E_commerce_System_currency.Models
{
    public class Order_details
    {
        public int OrderId { get; set; }

        public int ItemId { get; set; }

      
        public decimal ItemPrice { get; set; }

        public int Quanitity { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual Order Order { get; set; }

        public virtual Item Item { get; set; }

   
    }
}
