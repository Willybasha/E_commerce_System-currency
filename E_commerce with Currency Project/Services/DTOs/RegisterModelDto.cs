using System.ComponentModel.DataAnnotations;

namespace E_commerce_System_currency.Services.DTOs
{
    public class RegisterModelDto
    {
        [Required, MaxLength(50)]
        public string fullName { get; set; }

        [Required, MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(20)]
        public string Password { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(11)]
        public string Phone { get; set; }
    }
}
