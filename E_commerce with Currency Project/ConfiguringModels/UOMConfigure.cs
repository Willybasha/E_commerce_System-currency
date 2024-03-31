using E_commerce_System_currency.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce_System_currency.ConfiguringModels
{
    public class UOMConfigure : IEntityTypeConfiguration<UOMeasure>
    {
        public void Configure(EntityTypeBuilder<UOMeasure> builder)
        {
            builder.HasData
                (
                 new UOMeasure
                 {
                     Id = 1,
                     UOM = "KG",
                     Description = "KiloGram",
                 }
                );
        }
    }
}
