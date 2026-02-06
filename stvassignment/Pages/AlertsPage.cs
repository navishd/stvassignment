using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSE2522_Assignment02.Pages
{
    public class AlertsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public AlertsPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        // Navigate by URL (ok) but verify page by elements (more reliable)
        public void Open()
        {
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/alerts");
            WaitForButtons();
        }

        // Buttons on the Alerts page
        private readonly By _alertButton = By.Id("alertButton");
        private readonly By _confirmButton = By.Id("confirmButton");
        private readonly By _promptButton = By.Id("promptButton");

        // ✅ Reliable "page displayed" check: wait for buttons
        private void WaitForButtons()
        {
            _wait.Until(d => d.FindElement(_alertButton).Displayed);
            _wait.Until(d => d.FindElement(_confirmButton).Displayed);
            _wait.Until(d => d.FindElement(_promptButton).Displayed);
        }

        public bool IsPageDisplayed()
        {
            try
            {
                WaitForButtons();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IWebElement AlertButton => _wait.Until(d => d.FindElement(_alertButton));
        public IWebElement ConfirmButton => _wait.Until(d => d.FindElement(_confirmButton));
        public IWebElement PromptButton => _wait.Until(d => d.FindElement(_promptButton));

        public void ClickAlert() => AlertButton.Click();
        public void ClickConfirm() => ConfirmButton.Click();
        public void ClickPrompt() => PromptButton.Click();

        // ✅ Wait for an alert and return its text
        public string WaitForAlertText(int timeoutSeconds = 5)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    return d.SwitchTo().Alert().Text;
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            })!;
        }

        public void AcceptAlert()
        {
            _wait.Until(d =>
            {
                try
                {
                    d.SwitchTo().Alert().Accept();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public void DismissAlert()
        {
            _wait.Until(d =>
            {
                try
                {
                    d.SwitchTo().Alert().Dismiss();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public void SendTextToPrompt(string text)
        {
            _wait.Until(d =>
            {
                try
                {
                    d.SwitchTo().Alert().SendKeys(text);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
