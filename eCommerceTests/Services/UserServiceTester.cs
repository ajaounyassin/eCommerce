using System;
using eCommerce.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Model;
using Moq;
using Repositories.Interfaces;
using Repositories.Repositories;

namespace eCommerceTests
{
    [TestClass]
    public class UserServiceTester
    {

        private IUserService _userService;
        private IUserRepository _userRepository;


        public UserServiceTester()
        {
            _userRepository = new UserRepository(null);
            _userService = new UserService(_userRepository);
        }

        [TestMethod]
        public void GivenUserAlreadyInDb_WhenCreateNewUser_ThenReturnNull()
        {
            var mock = new Mock<IUserRepository>();
            var user = new User()
            {
                FirstName = "Ajaoun",
                LastName = "Yassin",
                BirthDate = DateTime.Now,
                Profil = Profil.Buyer,
                Mail = "ajaoun.yassin@gmail.com",
                Password = "password",
                Address = new Address()
                {
                    Number = 50,
                    Street = "Rue de la Horace",
                    PostCode = "67200",
                    City = "Horace",
                    Country = "France"
                },
                Sex = Sex.Female
            };

            mock.Setup(u => u.Add(user));

            var service = new UserService(mock.Object);
            var dbuser = service.Create(user);

            Assert.IsTrue(dbuser is null);
        }

        [TestMethod]
        public void GivenNullUser_WhenCreateNewUser_ThenReturnNull()
        {
            var mock = new Mock<IUserRepository>();

            var service = new UserService(mock.Object);
            var dbuser = service.Create(new User());

            Assert.IsNull(dbuser);
        }
    }
}
