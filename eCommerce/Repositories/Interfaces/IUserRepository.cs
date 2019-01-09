using System;
using System.Collections.Generic;
using Model.Model;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        //Create
        User Add(User user);

        //Read
        List<User> GetUserByFName(string UserFirstName);
        List<User> GetUserByLName(string UserLastName);
        List<User> GetUserByAddress(Address UserAddress);

        //Update
        User Update(Guid userId, User user);

        //Delete
        bool Delete(Guid id);
    }
}
