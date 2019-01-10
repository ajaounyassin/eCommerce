using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Model;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ECommerceDbContext _context;

        public UserRepository(ECommerceDbContext context)
        {
            this._context = context;
        }

        //Create
        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        ////Read
        //public List<User> GetUserByFName(string UserFirstName);
        //public List<User> GetUserByLName(string UserLastName);
        //public List<User> GetUserByAddress(Address UserAddress);

        ////Update
        //public User Update(Guid userId, User user);

        //Delete
        public bool Delete(Guid id)
        {
            if (this._context.Users.Find(id) != null)
            {
                _context.Users.Remove(_context.Users.Find(id));
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        
        }

    }
}
