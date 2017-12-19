using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AKQA.Exercise.AppLogic.Configuration;
using AKQA.Exercise.AppLogic.Services;
using AKQA.Exercise.Web;
using AKQA.Exercise.Web.Controllers;


namespace AKQA.Exercise.Web.Tests.Controllers
{
    [TestClass]
    [DeploymentItem("App.config")]
    public class HomeControllerTest
    {
        private const string _configFilePath = @"C:\Workspaces\AKQA\AKQA.Exercise\AKQA.Exercise.Web.Tests\NumWordsConvert.config";
        private readonly NumberWordConfig _numberWordConfig;
        private readonly INumToWords _numToWordsService;

        public HomeControllerTest()
        {
            var numberWordProvider = new NumberWordProvider();
            numberWordProvider.ConfigFilePath = _configFilePath;
            _numberWordConfig = numberWordProvider.BuildConfiguration();
            _numToWordsService = new NumToWords(_numberWordConfig);
        }


        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(_numToWordsService);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostUsernameTest()
        {
            // Arrange
            HomeController controller = new HomeController(_numToWordsService);

            // Act
            var result = controller.GetUsername("Test");

            // Assert
            Assert.AreEqual("Test", result.Data);
        }

        [TestMethod]
        public void PostNumberTest()
        {
            // Arrange
            HomeController controller = new HomeController(_numToWordsService);

            // Act
            var result = controller.GetNumberWord(1);

            // Assert
            Assert.AreEqual("ONE DOLLAR", result.Data);
        }
    }
}
