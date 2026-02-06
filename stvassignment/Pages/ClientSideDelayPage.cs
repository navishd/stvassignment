// Pages/ClientSideDelayPage.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSE2522_Assignment02.Pages
{
    public class ClientSideDelayPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ClientSideDelayPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        // Common IDs on UI Testing Playground
        private readonly By _button = By.Id("ajaxButton");

        // Spinner on many pages uses this class
        private readonly By _spinner = By.CssSelector(".spinner-border");

        // Result banner / label (commonly id="content" or text in #content)
        private readonly By _content = By.Id("content");

        public void Open()
        {
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/clientdelay");
        }

        public bool IsPageDisplayed()
        {
            return _wait.Until(d => d.Url.Contains("/clientdelay", StringComparison.OrdinalIgnoreCase));
        }

        public IWebElement Button => _wait.Until(d => d.FindElement(_button));

        public void ClickButton()
        {
            Button.Click();
        }

        public void WaitForLoadingToDisappear()
        {
            // Wait until spinner appears (if it does), then wait until it disappears.
            // If it never appears (fast machine), we still wait for content to update.
            try
            {
                _wait.Until(d =>
                {
                    var spinners = d.FindElements(_spinner);
                    foreach (var s in spinners)
                    {
                        if (s.Displayed) return true;
                    }
                    return false;
                });
            }
            catch
            {
                // spinner may not appear; ignore
            }

            // Wait for spinner to become invisible or absent
            _wait.Until(d =>
            {
                var spinners = d.FindElements(_spinner);
                foreach (var s in spinners)
                {
                    if (s.Displayed) return false;
                }
                return true;
            });

            // Also ensure result text exists
            _wait.Until(d => d.FindElement(_content).Text.Length > 0);
        }

        public string GetBannerText()
        {
            return _wait.Until(d => d.FindElement(_content)).Text.Trim();
        }
    }
}
