// Pages/SampleAppPage.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSE2522_Assignment02.Pages
{
    public class SampleAppPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public SampleAppPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private readonly By _username = By.Name("UserName");
        private readonly By _password = By.Name("Password");
        private readonly By _loginButton = By.Id("login");
        private readonly By _message = By.Id("loginstatus");

        public void Open()
        {
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/sampleapp");
        }

        public bool IsPageDisplayed()
        {
            return _wait.Until(d => d.Url.Contains("/sampleapp", StringComparison.OrdinalIgnoreCase));
        }

        public IWebElement Username => _wait.Until(d => d.FindElement(_username));
        public IWebElement Password => _wait.Until(d => d.FindElement(_password));
        public IWebElement LoginButton => _wait.Until(d => d.FindElement(_loginButton));

        public void Login(string user, string pass)
        {
            Username.Clear();
            Username.SendKeys(user);

            Password.Clear();
            Password.SendKeys(pass);

            LoginButton.Click();
        }

        public string GetMessageText()
        {
            return _wait.Until(d => d.FindElement(_message)).Text;
        }
    }
}
