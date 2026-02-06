using NUnit.Framework;
using CSE2522_Assignment02.Core;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class AlertsTests : BaseTest
    {
        [TestCase(TestName = "TC004_1 - Alerts - Verification of the Alerts page")]
        public void TC004_1_Alerts_VerifyPage()
        {
            var page = new AlertsPage(Driver, Wait);

            page.Open();
            Assert.That(page.IsPageDisplayed(), Is.True, "Alerts page not displayed.");

            Assert.That(page.AlertButton.Displayed, Is.True);
            Assert.That(page.ConfirmButton.Displayed, Is.True);
            Assert.That(page.PromptButton.Displayed, Is.True);
        }


        [TestCase(TestName = "TC004_2 - Alerts - Verification of the Alert text")]
        public void TC004_2_Alerts_AlertTextAndAccept()
        {
            var page = new AlertsPage(Driver, Wait);
            page.Open();

            page.ClickAlert();
            var alertText = page.WaitForAlertText();

            Assert.That(alertText, Does.Contain("Today"));
            page.AcceptAlert();

            
        }
        [TestCase(TestName = "TC004_3 - Alerts - Verification of the Confirm flow (Yes/No)")]
        public void TC004_3_Alerts_ConfirmYesNo()
        {
            var page = new AlertsPage(Driver, Wait);
            page.Open();

            // Confirm -> Accept -> second alert should be "Yes"
            page.ClickConfirm();
            var firstConfirmText = page.WaitForAlertText();
            Assert.That(firstConfirmText, Does.Contain("Agree").Or.Contain("Do you"));

            page.AcceptAlert();

            var yesAlertText = page.WaitForAlertText();
            Assert.That(yesAlertText, Does.Contain("Yes"), "Expected second alert to contain 'Yes'.");
            page.AcceptAlert();

            // Confirm -> Dismiss -> second alert should be "No"
            page.ClickConfirm();
            page.DismissAlert();

            var noAlertText = page.WaitForAlertText();
            Assert.That(noAlertText, Does.Contain("No"), "Expected second alert to contain 'No'.");
            page.AcceptAlert();
        }



        [TestCase(TestName = "TC004_4 - Alerts - Verification of the Prompt flow")]
        public void TC004_4_Alerts_PromptAcceptAndDismiss()
        {
            var page = new AlertsPage(Driver, Wait);
            page.Open();

            // Prompt -> input -> Accept -> second alert contains user value
            string input = "abc123";
            page.ClickPrompt();
            page.SendTextToPrompt(input);
            page.AcceptAlert();

            var acceptText = page.WaitForAlertText();
            Assert.That(acceptText, Does.Contain(input), "Expected second alert to contain the input text.");
            page.AcceptAlert();

            // Prompt -> input -> Dismiss -> second alert contains "No answer"
            page.ClickPrompt();
            page.SendTextToPrompt("ignored");
            page.DismissAlert();

            var dismissText = page.WaitForAlertText();
            Assert.That(dismissText.ToLower(), Does.Contain("no answer"), "Expected 'No answer' on dismiss.");
            page.AcceptAlert();
        }



    }
}
