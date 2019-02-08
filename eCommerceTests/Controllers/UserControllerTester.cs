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
        User user = new User()
        {
            Id = Guid.NewGuid(),
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
        public void TestCreateUser_WhenUserIsNull_ThenReturnStatusCode400()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(x => x.Create(new User())).Returns((User)null);
            var controller = new UserController(mock.Object);
            BadRequestObjectResult badRequest = new BadRequestObjectResult(ModelState);

            var result = controller.New(new User()) as BadRequestObjectResult;
            Assert.AreEqual(badRequest.StatusCode, result.StatusCode);

        }

        [TestMethod]
        public void TestCreateUser_WhenUserIsOk_ThenReturnStatusCode200()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(x => x.Create(user)).Returns(user);
            var controller = new UserController(mock.Object);
            OkResult OkRequest = new OkResult();

            var result = controller.New(user) as OkResult;
            Assert.AreEqual(OkRequest.StatusCode, result.StatusCode);

        }

        [TestMethod]
        public void TestdeleteUser_WhenUserOk_ThenReturnStatusCode204()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(x => x.Delete(user)).Returns(true);
            var controller = new UserController(mock.Object);
            NoContentResult noContentResult = new NoContentResult();

            var result = controller.Delete(user) as NoContentResult;
            Assert.AreEqual(noContentResult.StatusCode, result.StatusCode);

        }
    }
}
