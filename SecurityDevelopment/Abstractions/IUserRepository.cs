using System;
using System.Collections.Generic;
using System.Text;
using SecurityDevelopment.Models;
using SecurityDevelopment.Responses;
using SecurityDevelopment.Requests;
<<<<<<< HEAD
using SecurityDevelopmentAddUsers;
using System.Threading.Tasks;
=======
>>>>>>> main

namespace SecurityDevelopment.Abstractions
{
    public interface IUserRepository : IRepositoryCore<UserResponse, UserRequest>
    {
<<<<<<< HEAD
        public  void AddUsr(IReadOnlyList<UserRequest> item);
=======

>>>>>>> main
    }
}
