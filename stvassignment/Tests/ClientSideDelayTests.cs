// Tests/ClientSideDelayTests.cs
using NUnit.Framework;
using CSE2522_Assignment02.Core;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class ClientSideDelayTests : BaseTest
    {
        [TestCase(TestName = "TC003_1 - Client Side Delay - Verification of the page")]
        public void TC003_1_ClientSideDelay_Verify()
        {
            var page = new ClientSideDelayPage(Driver, Wait);

            page.Open();
            Assert.That(page.IsPageDisplayed(), Is.True, "Client Side Delay page was not displayed.");

            Assert.That(page.Button.Displayed, Is.True, "Button is not displayed.");

            page.ClickButton();
            page.WaitForLoadingToDisappear();

            var banner = page.GetBannerText();
            Assert.That(banner, Does.Contain("Data calculated on the client side."),
                "Expected banner text did not appear.");
        }
    }
}
