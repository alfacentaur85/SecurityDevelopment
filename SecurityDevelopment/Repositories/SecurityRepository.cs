using System;
using System.Collections.Generic;
using SecurityDevelopment.Abstractions;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Secutrity;
using SecurityDevelopment.Responses;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Data;
using Newtonsoft.Json;

namespace SecurityDevelopment.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;

        public SecurityRepository(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public async Task<IReadOnlyList<UserResponse>> GetByLoginPasswordAsync(string login, string password)
        {
            return  await _context.Users
              .Select(p => new UserResponse() { Id = p.Id, UserName = p.UserName, Password = p.Password, refreshToken = new RefreshToken() { id = p.refreshToken.id, Expires = p.refreshToken.Expires, Token = p.refreshToken.Token } })
              .Where(p => p.UserName.Equals(string.IsNullOrEmpty(login) ? "" : login) && p.Password.Equals(string.IsNullOrEmpty(password) ? "" : password))
              .ToArrayAsync();
        }
    }
}
