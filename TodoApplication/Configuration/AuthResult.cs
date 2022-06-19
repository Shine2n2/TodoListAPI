using System.Collections.Generic;

namespace TodoApplication.Configuration
{
    public class AuthResult
    {
        public string Token { get; set; }
        public string RefreshTOken { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
