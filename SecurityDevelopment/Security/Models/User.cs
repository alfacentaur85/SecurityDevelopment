
namespace Secutrity
{
    public sealed class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public RefreshToken refreshToken { get; set; }
    }
}
