namespace E_commerce_System_currency.Services.DTOs
{
    public class AuthModel
    {
        public string message { get; set; }

        public bool IsAuthenticated { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public List<string> Roles { get; set; }

        public string Token { get; set; }

        public DateTime ExpireOn { get; set; }
    }
}
