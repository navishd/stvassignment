// Tests/SampleAppTests.cs
using NUnit.Framework;
using CSE2522_Assignment02.Core;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class SampleAppTests : BaseTest
    {
        [TestCase(TestName = "TC002_1 - Sample App - Verification of the sample app page")]
        public void TC002_1_SampleApp_VerifyPageElements()
        {
            var page = new SampleAppPage(Driver, Wait);

            page.Open();
            Assert.That(page.IsPageDisplayed(), Is.True, "Sample App page was not displayed.");

            Assert.That(page.Username.Displayed, Is.True, "Username field is not displayed.");
            Assert.That(page.Password.Displayed, Is.True, "Password field is not displayed.");
            Assert.That(page.LoginButton.Displayed, Is.True, "Login button is not displayed.");
        }

        [TestCase(TestName = "TC002_2 - Sample App - Verification of a successful login")]
        public void TC002_2_SampleApp_SuccessfulLogin()
        {
            var page = new SampleAppPage(Driver, Wait);

            page.Open();

            // UI Testing Playground commonly uses: User / pwd
            page.Login("User", "pwd");

            var msg = page.GetMessageText();
            Assert.That(msg.ToLower(), Does.Contain("welcome"), "Welcome message did not appear.");
        }

        [TestCase(TestName = "TC002_3 - Sample App - Verification of an unsuccessful login")]
        public void TC002_3_SampleApp_UnsuccessfulLogin()
        {
            var page = new SampleAppPage(Driver, Wait);

            page.Open();

            page.Login("User", "wrongpwd");

            var msg = page.GetMessageText();
            Assert.That(msg.ToLower(), Does.Contain("invalid"), "Invalid username/password message did not appear.");
        }
    }
}
