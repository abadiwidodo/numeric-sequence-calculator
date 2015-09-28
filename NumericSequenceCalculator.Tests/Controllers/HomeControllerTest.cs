using System.Net;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace NumericSequenceCalculator.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest :SeleniumTest
    {
        public HomeControllerTest() : base("NumericSequenceCalculator") { }

        [TestMethod]
        public void When_Input_Empty_Should_Validate_Input()
        {
            // Act
            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("InputNumber")).Clear();
            this.FirefoxDriver.FindElement(By.Id("btnCalculate")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.ClassName("field-validation-error")).Text.Equals("Please enter a number"));
        }

        [TestMethod]
        public void When_Input_String_Chars_Should_Validate_Input()
        {
            // Act
            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("InputNumber")).Clear();
            this.FirefoxDriver.FindElement(By.Id("InputNumber")).SendKeys("ABCDEFGHIJKLMN");
            this.FirefoxDriver.FindElement(By.Id("btnCalculate")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.ClassName("field-validation-error")).Text.Equals("Please enter a number"));
        }

        [TestMethod]
        public void When_Input_Minus_Should_Validate_Input()
        {
            // Act
            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("InputNumber")).Clear();
            this.FirefoxDriver.FindElement(By.Id("InputNumber")).SendKeys("-1000000");
            this.FirefoxDriver.FindElement(By.Id("btnCalculate")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.ClassName("field-validation-error")).Text.Equals("The input must be positive number"));
        }

        [TestMethod]
        public void When_Input_0_Should_Return_Empty()
        {
            // Act
            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("InputNumber")).Clear();
            this.FirefoxDriver.FindElement(By.Id("InputNumber")).SendKeys("0");
            this.FirefoxDriver.FindElement(By.Id("btnCalculate")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divSequenceNormal")).Text.Trim().Equals(""));
        }

        [TestMethod]
        public void When_Input_10_Should_Return_Sequence_1_2_3_4_5_6_7_8_9_10()
        {
            // Act
            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("InputNumber")).Clear();
            this.FirefoxDriver.FindElement(By.Id("InputNumber")).SendKeys("10");
            this.FirefoxDriver.FindElement(By.Id("btnCalculate")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divSequenceNormal")).Text.Trim().Contains("1 2 3 4 5 6 7 8 9 10"));
        }

        [TestMethod]
        public void When_Input_1000000_Should_Return_Sequence_Until_500000_Only_And_Show_Load_button()
        {
            // Act
            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("InputNumber")).Clear();
            this.FirefoxDriver.FindElement(By.Id("InputNumber")).SendKeys("10000000");
            this.FirefoxDriver.FindElement(By.Id("btnCalculate")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divSequenceNormal")).Text.Trim().Contains("99999 100000"));
        }
    }
}
