using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_System_currency.Models
{
    public class UOMeasure
    {
        [Key]
        public int Id { get; set; }
        public string UOM { get; set; }
        public string Description { get; set; }
        public ICollection<Item> Items{get; set;}
    }
       
}
