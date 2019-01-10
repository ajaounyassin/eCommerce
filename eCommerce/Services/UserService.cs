using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Repositories.Repositories;

public class UserService : IUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<User> _users = new List<User>
        {
            new User { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", Password = "test" }
        };

    public async Task<User> Authenticate(string firstname, string password)
    {
        var user = await Task.Run(() => _users.SingleOrDefault(x => x.FirstName == firstname && x.Password == password));

        // return null if user not found
        if (user == null)
            return null;

        // authentication successful so return user details without password
        user.Password = null;
        return user;
    }

    public User CreateUser(User user)
    { 
        _users.Add(user);

        return user;
    }
}

