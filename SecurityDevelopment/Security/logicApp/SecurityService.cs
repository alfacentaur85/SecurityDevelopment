using System;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using SecurityDevelopment.Abstractions;

namespace Secutrity
{
    public sealed class SecurityService : ISecurityService
    {
        private IDictionary<string, AuthResponse> _users = new Dictionary<string, AuthResponse>();

        private ISecurityRepository _repository;

        public SecurityService(ISecurityRepository repository)
        {
            _repository = repository;
        }

        public const string SecretCode = "df;ko%k;ky)=-=965;ljdfjmfg;i";

        public TokenResponse Authenticate(string user, string password)
        {
            var r = _repository.GetByLoginPasswordAsync(user, password);

            if (r.Result.Count == 0)
            {
                return null;
            }
            
            _users.Add(user, new AuthResponse() { Password = password});

            TokenResponse tokenResponse = new TokenResponse();
            foreach (KeyValuePair<string, AuthResponse> pair in _users)
            {
                if (string.CompareOrdinal(pair.Key, user) == 0 && string.CompareOrdinal(pair.Value.Password, password) == 0)
                {
                    tokenResponse.Token = GenerateJwtToken(pair.Key, 15);
                    RefreshToken refreshToken = GenerateRefreshToken(pair.Key);
                    pair.Value.LatestRefreshToken = refreshToken;
                    tokenResponse.RefreshToken = refreshToken.Token;
                    return tokenResponse;

                }

            }

            return null;
        }

        public string RefreshToken(string token)
        {
            foreach (KeyValuePair<string, AuthResponse> pair in _users)
            {
                if (string.CompareOrdinal(pair.Value.LatestRefreshToken.Token, token) == 0
                    && pair.Value.LatestRefreshToken.IsExpired is false)
                {
                    pair.Value.LatestRefreshToken = GenerateRefreshToken(pair.Key);
                    return pair.Value.LatestRefreshToken.Token;
                }
            }
            return string.Empty;
        }

        private static string GenerateJwtToken(string value, int minutes)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretCode);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, value)
                }),
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public static RefreshToken GenerateRefreshToken(string value)
        {
            RefreshToken refreshToken = new RefreshToken();
            refreshToken.Expires = DateTime.Now.AddMinutes(360);
            refreshToken.Token = GenerateJwtToken(value, 360);
            return refreshToken;
        }
    }
}




