using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Models.DTO.Request
{
    public class UserRegistrationDTO
    {
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
