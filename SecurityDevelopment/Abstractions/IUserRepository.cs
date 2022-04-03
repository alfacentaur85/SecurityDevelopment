using System;
using System.Collections.Generic;
using System.Text;
using SecurityDevelopment.Models;
using SecurityDevelopment.Responses;
using SecurityDevelopment.Requests;
using SecurityDevelopmentAddUsers;
using System.Threading.Tasks;

namespace SecurityDevelopment.Abstractions
{
    public interface IUserRepository : IRepositoryCore<UserResponse, UserRequest>
    {
        public  void AddUsr(IReadOnlyList<UserRequest> item);
    }
}
