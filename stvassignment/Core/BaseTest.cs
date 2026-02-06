// Core/BaseTest.cs
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSE2522_Assignment02.Core
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver = null!;
        protected WebDriverWait Wait = null!;

        // Base URL for all pages
        protected const string BaseUrl = "https://uitestingplayground.com/";

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            Driver = new ChromeDriver(options);

            // Explicit wait (recommended)
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));

            // Go to home page as a common precondition
            Driver.Navigate().GoToUrl(BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                Driver?.Quit();
            }
            catch
            {
                // ignore cleanup issues
            }
        }

        protected IWebElement FindVisible(By by)
        {
            return Wait.Until(d =>
            {
                var el = d.FindElement(by);
                return el.Displayed ? el : null;
            })!;
        }

        protected bool IsElementDisplayed(By by)
        {
            try
            {
                var el = Driver.FindElement(by);
                return el.Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
