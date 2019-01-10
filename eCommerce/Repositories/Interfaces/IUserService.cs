using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace eCommerce.Repositories.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(string firstname, string password);
        User CreateUser(User user);
        
    }

}
