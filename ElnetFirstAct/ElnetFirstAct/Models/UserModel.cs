using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ElnetFirstAct.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } = "";

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Password {  get; set; } = "";

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
