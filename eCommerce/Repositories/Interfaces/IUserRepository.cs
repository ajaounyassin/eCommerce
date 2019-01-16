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
        User GetOne(string mail);
        bool CheckExist(User user);
        List<User> GetAll();

        //Delete
        bool Delete(Guid id);

    }
}
