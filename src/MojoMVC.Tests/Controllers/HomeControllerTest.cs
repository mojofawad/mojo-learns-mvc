using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MojoMVC.Controllers;
using System.Web.Mvc;

namespace MojoMVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public async Task Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
