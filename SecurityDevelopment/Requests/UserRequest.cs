

namespace SecurityDevelopment.Requests
{
    public class UserRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public RefreshTokenRequest refreshToken { get; set; }
    }
}
