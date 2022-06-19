using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Models
{
    public class UserV1
    {
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
