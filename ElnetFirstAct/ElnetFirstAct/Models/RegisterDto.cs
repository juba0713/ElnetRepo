using Microsoft.AspNetCore.Mvc;

namespace ElnetFirstAct.Models
{
    public class RegisterDto
    {
        public string Email { get; set; } = "";

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Password { get; set; } = "";

        public string ConPassword { get; set; } = "";

        public string ErrorMessage { get; set; } = "";
    }
}
