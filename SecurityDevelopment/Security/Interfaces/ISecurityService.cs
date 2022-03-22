
namespace Secutrity
{
    public interface ISecurityService
    {
        TokenResponse Authenticate(string user, string password);

        string RefreshToken(string token);
    }
}
