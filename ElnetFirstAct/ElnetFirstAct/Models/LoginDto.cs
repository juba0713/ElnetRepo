using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ElnetFirstAct.Models
{
    public class LoginDto
    {
        public string Email { get; set; } = "";

        public string Password { get; set; } = "";

    }
}
