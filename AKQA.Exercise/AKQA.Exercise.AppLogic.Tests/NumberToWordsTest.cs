using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AKQA.Exercise.AppLogic.Configuration;
using AKQA.Exercise.AppLogic.Services;

namespace AKQA.Exercise.AppLogic.Tests
{
    [TestClass]
    public class NumberToWordsTest
    {
        private const string _configFilePath = @"C:\Workspaces\AKQA\AKQA.Exercise\AKQA.Exercise.AppLogic.Tests\NumWordsConvert.config";
        private readonly NumberWordConfig _numberWordConfig;
        private readonly INumToWords _numToWordsService;

        public NumberToWordsTest()
        {
            var numberWordProvider = new NumberWordProvider();
            numberWordProvider.ConfigFilePath = _configFilePath;
            _numberWordConfig = numberWordProvider.BuildConfiguration();
            _numToWordsService = new NumToWords(_numberWordConfig);
        }

        [TestMethod]
        public void ZeroTest1()
        {
            var acture = _numToWordsService.ConvertNumToWords(0);
            var expected = "ZERO DOLLAR";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void ZeroTest2()
        {
            var acture = _numToWordsService.ConvertNumToWords(0.0000);
            var expected = "ZERO DOLLAR";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void ZeroTest3()
        {
            var acture = _numToWordsService.ConvertNumToWords(0.0044);
            var expected = "ZERO DOLLAR";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void LessThanOneTest1()
        {
            var acture = _numToWordsService.ConvertNumToWords(0.01);
            var expected = "ONE CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void LessThanOneTest2()
        {
            var acture = _numToWordsService.ConvertNumToWords(0.99);
            var expected = "NINETY-NINE CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void OneTest1()
        {
            var acture = _numToWordsService.ConvertNumToWords(0.999);
            var expected = "ONE DOLLAR";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void OneTest2()
        {
            var acture = _numToWordsService.ConvertNumToWords(1);
            var expected = "ONE DOLLAR";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void OneTest3()
        {
            var acture = _numToWordsService.ConvertNumToWords(1.00);
            var expected = "ONE DOLLAR";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void OneTest4()
        {
            var acture = _numToWordsService.ConvertNumToWords(1.001);
            var expected = "ONE DOLLAR";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void LessThanTwenty1()
        {
            var acture = _numToWordsService.ConvertNumToWords(2.1);
            var expected = "TWO DOLLAR TEN CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void LessThanTwenty2()
        {
            var acture = _numToWordsService.ConvertNumToWords(13.14);
            var expected = "THIRTEEN DOLLAR FOURTEEN CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void LessThanHundred1()
        {
            var acture = _numToWordsService.ConvertNumToWords(50.00);
            var expected = "FIFTY DOLLAR";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void LessThanHundred2()
        {
            var acture = _numToWordsService.ConvertNumToWords(43.210);
            var expected = "FORTY-THREE DOLLAR TWENTY-ONE CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void LessThanThousand1()
        {
            var acture = _numToWordsService.ConvertNumToWords(123.45);
            var expected = "ONE HUNDRED TWENTY-THREE DOLLAR FORTY-FIVE CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void LessThanThousand2()
        {
            var acture = _numToWordsService.ConvertNumToWords(987.65);
            var expected = "NINE HUNDRED EIGHTY-SEVEN DOLLAR SIXTY-FIVE CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void Thousands1()
        {
            var acture = _numToWordsService.ConvertNumToWords(1000.00);
            var expected = "ONE THOUSAND DOLLAR";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void Thousands2()
        {
            var acture = _numToWordsService.ConvertNumToWords(9999.99);
            var expected = "NINE THOUSAND NINE HUNDRED NINETY-NINE DOLLAR NINETY-NINE CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void Thousands3()
        {
            var acture = _numToWordsService.ConvertNumToWords(99999.99);
            var expected = "NINETY-NINE THOUSAND NINE HUNDRED NINETY-NINE DOLLAR NINETY-NINE CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void Thousands4()
        {
            var acture = _numToWordsService.ConvertNumToWords(999999.99);
            var expected = "NINE HUNDRED NINETY-NINE THOUSAND NINE HUNDRED NINETY-NINE DOLLAR NINETY-NINE CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void Million1()
        {
            var acture = _numToWordsService.ConvertNumToWords(9999999.99);
            var expected = "NINE MILLION NINE HUNDRED NINETY-NINE THOUSAND NINE HUNDRED NINETY-NINE DOLLAR NINETY-NINE CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void Million2()
        {
            var acture = _numToWordsService.ConvertNumToWords(999999999.99);
            var expected = "NINE HUNDRED NINETY-NINE MILLION NINE HUNDRED NINETY-NINE THOUSAND NINE HUNDRED NINETY-NINE DOLLAR NINETY-NINE CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void Billions1()
        {
            var acture = _numToWordsService.ConvertNumToWords(9999999999.99);
            var expected = "NINE BILLION NINE HUNDRED NINETY-NINE MILLION NINE HUNDRED NINETY-NINE THOUSAND NINE HUNDRED NINETY-NINE DOLLAR NINETY-NINE CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void Billions2()
        {
            var acture = _numToWordsService.ConvertNumToWords(999999999999.99);
            var expected = "NINE HUNDRED NINETY-NINE BILLION NINE HUNDRED NINETY-NINE MILLION NINE HUNDRED NINETY-NINE THOUSAND NINE HUNDRED NINETY-NINE DOLLAR NINETY-NINE CENT";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void OutOffRange1()
        {
            var acture = _numToWordsService.ConvertNumToWords(999999999999.999);
            var expected = "OUT OFF RANGE";
            Assert.AreEqual(expected, acture);
        }

        [TestMethod]
        public void OutOffRange2()
        {
            var acture = _numToWordsService.ConvertNumToWords(-0.001);
            var expected = "OUT OFF RANGE";
            Assert.AreEqual(expected, acture);
        }
    }
}
