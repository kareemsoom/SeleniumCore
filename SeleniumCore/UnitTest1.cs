using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace SeleniumCore
{
    [TestClass]
    public class HomepageFeature
    {
        [TestMethod]
        public void ShouldBeAbleToLogin()
        {
            string outputDirectory = Path.GetDirectoryName
                (Assembly.GetExecutingAssembly().Location);


            var driver = new ChromeDriver(outputDirectory);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            //driver.Close();
        }
    }
}
