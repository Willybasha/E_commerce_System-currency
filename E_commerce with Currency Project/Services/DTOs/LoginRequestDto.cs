using System.ComponentModel.DataAnnotations;

namespace E_commerce_System_currency.Services.DTOs
{
    public class LoginRequestDto
    {
        [Required, MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
