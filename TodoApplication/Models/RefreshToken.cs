using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApplication.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime  AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        [ForeignKey(nameof(UserID))]
        public IdentityUser User { get; set; }
    }
}
