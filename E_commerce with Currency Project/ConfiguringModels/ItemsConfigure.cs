using E_commerce_System_currency.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace E_commerce_System_currency.ConfiguringModels
{
    public class ItemsConfigure : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasData
            (
                new Item
                {
                    Id = 1,
                    ItemName = "A1",
                    Description = "desc1",
                    Quantity = 10000,
                    Price = 1500,
                    UOMeasureId = 1,
                },
                new Item 
                {
                    Id=2,
                    ItemName= "A2",
                    Description="desc2",
                    Quantity=2500,
                    Price=2800,
                    UOMeasureId=1
                },
                 new Item
                 {
                     Id = 3,
                     ItemName = "A3",
                     Description = "desc3",
                     Quantity = 3700,
                     Price = 200,
                     UOMeasureId = 1
                 } 
            );
        }
    }
}
