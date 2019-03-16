using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Support.UI;


namespace SeleniumCore
{
    [TestClass]
    public class HomepageFeature
    {
        IWebDriver _driver;

        [TestMethod]
        public void ShouldBeAbleToLogin()
        {
            string outputDirectory = Path.GetDirectoryName
                (Assembly.GetExecutingAssembly().Location);


            _driver = new ChromeDriver(outputDirectory);
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

           var loginButtonLocator = (By.ClassName("btn_action"));
           var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(loginButtonLocator));

            var userNameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(By.ClassName("btn_action"));

            userNameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();

            Assert.IsTrue(_driver.Url.Contains("inventory.html"));

            //driver.Close();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}
