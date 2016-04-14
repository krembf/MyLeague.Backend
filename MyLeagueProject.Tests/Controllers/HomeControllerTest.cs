using System.Web.Mvc;
using WebAPITemplateProject;
using WebAPITemplateProject.Controllers;
using NUnit.Framework;

namespace WebAPITemplateProject.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [TestCase]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
