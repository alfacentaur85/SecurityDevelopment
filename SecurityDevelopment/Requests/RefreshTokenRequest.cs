using System;

namespace SecurityDevelopment.Requests
{
    public class RefreshTokenRequest
    {

        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;
    }
}
