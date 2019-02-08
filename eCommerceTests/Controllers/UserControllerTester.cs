using System;
using eCommerce.Controllers;
using eCommerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Model;
using Moq;

namespace eCommerceTests.Controllers
{
    [TestClass]
    public class UserControllerTester : ControllerBase
    {
        private UserController _userController;
        private IUserService _userService;
        User user = new User()
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


        [TestMethod]
        public void TestCreateUser_WhenUserIsNull_ThenReturnBadRequest()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(x => x.Create(new User())).Returns((User)null);
            var controller = new UserController(mock.Object);

            var result = controller.New(new User());
            Assert.AreEqual(400, result);

        }
    }
}
