using System;
using System.Collections.Generic;
using SecurityDevelopment.Abstractions;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SecurityDevelopment.Responses;
using SecurityDevelopment.Requests;
using Secutrity;
using Npgsql;
using Microsoft.Extensions.Configuration;
<<<<<<< HEAD
using SecurityDevelopmentAddUsers;
using SecurityDevelopment.Assemblies;
using System.Reflection;
using System.Runtime.Loader;
using System.IO;

=======
>>>>>>> main

namespace SecurityDevelopment.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IReadOnlyList<UserResponse>> GetByIdAsync(int id)
        {
            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                return await _context.Users
                  .Select(p => new UserResponse() { Id = p.Id, UserName = p.UserName, Password = p.Password, refreshToken = new RefreshToken() { id = p.refreshToken.id, Expires = p.refreshToken.Expires, Token = p.refreshToken.Token } })
                  .Where(p => p.Id == id)
                  .ToArrayAsync();
            }
        }

        public async Task<IReadOnlyList<UserResponse>> GetByNameAsync(string name)
        {
            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                return await _context.Users
                  .Select(p => new UserResponse() { Id = p.Id, UserName = p.UserName, Password = p.Password, refreshToken = new RefreshToken() { id = p.refreshToken.id, Expires = p.refreshToken.Expires, Token = p.refreshToken.Token } })
                  .Where(p => p.UserName.Contains(string.IsNullOrEmpty(name) ? "" : name))
                  .ToArrayAsync();
            }
        }

        public async Task<IReadOnlyList<UserResponse>> GetByLoginPasswordAsync(string login, string password)
        {
            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                return await _context.Users
                  .Select(p => new UserResponse() { Id = p.Id, UserName = p.UserName, Password = p.Password, refreshToken = new RefreshToken() { id = p.refreshToken.id, Expires = p.refreshToken.Expires, Token = p.refreshToken.Token } })
                  .Where(p => p.UserName.Equals(string.IsNullOrEmpty(login) ? "" : login) && p.Password.Equals(string.IsNullOrEmpty(password) ? "" : password))
                  .ToArrayAsync();
            }
        }

        public async Task<IReadOnlyList<UserResponse>> GetWithPaginationAsync(int skip, int take, string search)
        {
            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                return await _context.Users
                  .Select(p => new UserResponse() { Id = p.Id, UserName = p.UserName, Password = p.Password, refreshToken = new RefreshToken() { id = p.refreshToken.id, Expires = p.refreshToken.Expires, Token = p.refreshToken.Token } })
                  .Where(p => p.UserName.Contains(string.IsNullOrEmpty(search) ? "" : search))
                  .Skip(skip)
                  .Take(take)
                  .ToArrayAsync();
            }
        }


        public async Task AddAsync(IReadOnlyList<UserRequest> item)
        {
            foreach (var p in item.ToList())
            {
                string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

                using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
                {
                    npgsqlConnection.Open();
                    await _context.Users.AddAsync(new User() { UserName = p.UserName, Password = p.Password, refreshToken = SecurityService.GenerateRefreshToken(p.UserName) });
                    await _context.SaveChangesAsync();
                }
            }
        }
<<<<<<< HEAD

        public async Task AddUser(IReadOnlyList<UserRequest> item)
        {
            (string name, string password) account; 
                
            foreach (var p in item.ToList())
            {
                var context = new CustomAssemblyLoadContext();

                context.Unloading += CustomAssemblyLoadContext.Context_Unloading;

                var assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), "SecurityDevelopmentAddUser.dll");

                Assembly assembly = context.LoadFromAssemblyPath(assemblyPath);

                var type = assembly.GetType("SecurityDevelopmentAddUser.Program");

                var greetMethod = type.GetMethod("AddUser");

                account = ((string name, string password))greetMethod.Invoke(new object[] { p.UserName }, new object[]{p.Password });

                context.Unload();


                string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

                using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
                {
                    npgsqlConnection.Open();
                    await _context.Users.AddAsync(new User() { UserName = account.name, Password = account.password, refreshToken = SecurityService.GenerateRefreshToken(account.name) });
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async void AddUsr(IReadOnlyList<UserRequest> item)
        {
            await AddUser(item);
        }

=======
>>>>>>> main
        public async Task UpdateAsync(IReadOnlyList<UserRequest> item)
        {
            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                foreach (var p in item.ToList())
                {

                    var entity = await _context
                                .Users
                                .Where(entity => entity.UserName == p.UserName)
                                .FirstOrDefaultAsync();
                    if (entity != null)
                    {
                        entity.UserName = p.UserName;
                        entity.Password = p.Password;
                        entity.refreshToken = SecurityService.GenerateRefreshToken(p.UserName);
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                var entity = await _context
                    .Users
                    .Where(entity => entity.Id == id)
                    .FirstOrDefaultAsync();
                if (entity != null)
                {
                    _context.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }

        }
    }
}
