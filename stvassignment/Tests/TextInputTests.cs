// Tests/TextInputTests.cs
using NUnit.Framework;
using CSE2522_Assignment02.Core;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class TextInputTests : BaseTest
    {
        [TestCase(TestName = "TC001_1 - Text Input - Verification of the page")]
        public void TC001_1_TextInput_VerificationOfThePage()
        {
            var page = new TextInputPage(Driver, Wait);

            page.Open();
            Assert.That(page.IsPageDisplayed(), Is.True, "Text Input page was not displayed.");

            Assert.That(page.TextBox.Displayed, Is.True, "Text box is not displayed.");
            Assert.That(page.Button.Displayed, Is.True, "Button is not displayed.");

            var randomText = "Hello123";
            page.EnterText(randomText);
            page.ClickButton();

            Assert.That(page.GetButtonText(), Is.EqualTo(randomText), "Button text did not change to entered text.");
        }
    }
}
