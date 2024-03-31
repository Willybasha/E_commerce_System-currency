using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace E_commerce_System_currency.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(40)]
        public string fullname { get; set; }
    }
}
