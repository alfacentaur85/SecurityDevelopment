using System;
using System.Collections.Generic;
using System.Text;
using SecurityDevelopment.Models;
using SecurityDevelopment.Responses;
using SecurityDevelopment.Requests;



namespace SecurityDevelopment.Abstractions
{
    public interface ISecurityRepository : IRepositorySecurity<UserResponse, UserRequest>
    {

    }
}
