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
        private IShoppingCartRepository _shoppingCartRepository;


        public UserServiceTester()
        {
            _userRepository = new UserRepository(null);
            _shoppingCartRepository = new ShoppingCartRepository(null);
            _userService = new UserService(_userRepository, _shoppingCartRepository);
        }

        [TestMethod]
        public void GivenUserAlreadyInDb_WhenCreateNewUser_ThenReturnNull()
        {
            var mock = new Mock<IUserRepository>();
            var mockSc = new Mock<IShoppingCartRepository>();
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

            var service = new UserService(mock.Object,mockSc.Object);
            var dbuser = service.Create(user);

            Assert.IsNull(dbuser);
        }

        [TestMethod]
        public void GivenNullUser_WhenCreateNewUser_ThenReturnNull()
        {
            var mock = new Mock<IUserRepository>();
            var mockSc = new Mock<IShoppingCartRepository>();

            mock.Setup((x => x.Add(It.IsAny<User>()))).Returns(new User());

            var service = new UserService(mock.Object, mockSc.Object);
            var dbuser = service.Create(new User());

            Assert.IsNull(dbuser);
        }

        [TestMethod]
        public void GivenUser_WhenCreateNewUser_ThenReturnUser()
        {
            var mock = new Mock<IUserRepository>();
            var mockSc = new Mock<IShoppingCartRepository>();
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

            mock.Setup((x => x.Add(It.IsAny<User>()))).Returns(user);

            var service = new UserService(mock.Object,mockSc.Object);
            var dbuser = service.Create(user);

            Assert.AreEqual(user,dbuser);
        }
    }
}
