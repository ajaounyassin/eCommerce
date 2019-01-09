using System;

namespace Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ECommerceDbContext _context;

        public ShoppingCartRepository(ECommerceDbContext context)
        {
            this._context = context;
        }

        //Create
        User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        //Read
        List<User> GetUserByFName(string UserFirstName);
        List<User> GetUserByLName(string UserLastName);
        List<User> GetUserByAddress(Address UserAddress);

        //Update
        User Update(Guid userId, User user);

        //Delete
        bool Delete(Guid id)
        {
            if (this._context.Users.Find(id) != null)
            {
                _context.Users.Remove(_context.Users.Find(id));
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
