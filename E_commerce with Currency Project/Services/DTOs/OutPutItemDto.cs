namespace E_commerce_System_currency.Services.DTOs
{
    public class OutPutItemDto
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int UOMeasureId { get; set; }
    }
}
