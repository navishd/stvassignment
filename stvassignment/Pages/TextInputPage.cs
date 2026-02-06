using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSE2522_Assignment02.Pages
{
    public class TextInputPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public TextInputPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        // Click link from home (more reliable than direct URL sometimes)
        private readonly By _textInputLink = By.LinkText("Text Input");

        // Robust locators
        private readonly By _textBox = By.CssSelector("#newButtonName, input[id='newButtonName']");
        private readonly By _button = By.CssSelector("#updatingButton, button[id='updatingButton']");

        public void Open()
        {
            // go home first
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/");
            _wait.Until(d => d.FindElement(_textInputLink)).Click();

            // wait until textbox exists
            _wait.Until(d => d.FindElement(_textBox).Displayed);
        }

        public bool IsPageDisplayed() =>
            _wait.Until(d => d.Url.Contains("/textinput", StringComparison.OrdinalIgnoreCase));

        public IWebElement TextBox => _wait.Until(d => d.FindElement(_textBox));
        public IWebElement Button => _wait.Until(d => d.FindElement(_button));

        public void EnterText(string text)
        {
            TextBox.Clear();
            TextBox.SendKeys(text);
        }

        public void ClickButton() => Button.Click();

        public string GetButtonText() => Button.Text;
    }
}
