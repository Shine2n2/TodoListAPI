using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Models.DTO.Request
{
    public class UserLogging
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
