using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Models.DTO.Request
{
    public class TokenRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefereshToken { get; set; }
    }
}
