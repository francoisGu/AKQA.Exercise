using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AKQA.Exercise.AppLogic.Configuration;

namespace AKQA.Exercise.AppLogic.Tests
{
    [TestClass]
    [DeploymentItem("App.config")]
    public class NumberWordConfigTest
    {
        private const string configFilePath = @"C:\Workspaces\AKQA\AKQA.Exercise\AKQA.Exercise.AppLogic.Tests\NumWordsConvert.config";

        /// <summary>
        /// Check if get the path from web.config
        /// </summary>
        [TestMethod]
        public void TestGetConfigPath()
        {
            var numberWordProvider = new NumberWordProvider();
            var acture = numberWordProvider.GetEntry("NumWordsConvertPath");
            var expected = @"App_Config\NumWordsConvert.Config";
            Assert.AreEqual(expected, acture);
        }

        /// <summary>
        /// Check if create config model
        /// </summary>
        [TestMethod]
        public void TestGetConfigFile()
        {
            var numberWordProvider = new NumberWordProvider();
            numberWordProvider.ConfigFilePath = configFilePath;
            var numberWordConfig = numberWordProvider.BuildConfiguration();            
            Assert.IsNotNull(numberWordConfig);
        }

        /// <summary>
        /// if it get all config
        /// </summary>
        [TestMethod]
        public void TestGetAllConfigNumberInConfig()
        {
            var numberWordProvider = new NumberWordProvider();
            numberWordProvider.ConfigFilePath = configFilePath;
            var numberWordDict = numberWordProvider.BuildConfiguration().NumberWords;

            Assert.AreEqual(numberWordDict.Count, 27);
        }

        /// <summary>
        /// if it get certain config
        /// </summary>
        [TestMethod]
        public void TestGetConfigNumberInConfig()
        {
            var numberWordProvider = new NumberWordProvider();
            numberWordProvider.ConfigFilePath = configFilePath;
            var numberWordDict = numberWordProvider.BuildConfiguration().NumberWords;

            Assert.AreEqual(numberWordDict[1], "one");
        }
    }
}
