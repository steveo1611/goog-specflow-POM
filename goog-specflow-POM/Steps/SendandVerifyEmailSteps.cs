using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using goog_specflow_POM.Pages;
using System.Threading;
using goog_specflow_POM.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace goog_specflow_POM.Steps
{
    [Binding]
       public class SendandVerifyEmailSteps
    {
        private readonly ScenarioContext context;
        static IWebDriver driver = null;
        logIn logIn = new logIn(driver);
        InboxPage inbox = new InboxPage(driver);
        ComposeEmailPage compose = new ComposeEmailPage(driver);
       public SendandVerifyEmailSteps(ScenarioContext injectedContext )
        {
             context = injectedContext;
        }
       static readonly DateTime stamp = DateTime.Now;
       public static DateTime Stamp => stamp;
                
        //       readonly JObject fileReader = new ReadJSONFile().OpenJsonFile("configs\\Credentials.json");
        
        [Given(@"I successfully Log into GMail account")]
        public void GivenISuccessfullyLogIntoGMailAccount()
        {
            var driver = (IWebDriver)context["webdriver"];
            string home = driver.Url;
            Assert.IsTrue(home == "https://mail.google.com/mail/u/0/#inbox", "Failed to Login...");

        }

        [Then(@"I verify I am on the Inbox page")]
        public void ThenIVerifyIAmOnTheInboxPage()
        {
            var driver = (IWebDriver)context["webdriver"];
            Assert.IsTrue(inbox.VerifyLoggedIn(driver));
        }

        [When(@"I compose new email")]
        public void WhenIComposeNewEmail()
        {
            var driver = (IWebDriver)context["webdriver"];
            inbox.SelectComposeButton(driver);
            Assert.IsTrue(compose.ValidateEmailOpen(driver));
            compose.EnterToEmail(driver, "xxx" + "@gmail.com");
            compose.EnterSubjectEmail(driver, "THIS IS A TEST " + stamp);
            compose.EnterBodyText(driver, "this is a test");
        }
        
        [When(@"Send email to myself")]
        public void WhenSendEmailToMyself()
        {
            var driver = (IWebDriver)context["webdriver"];
            compose.clickSendEmailButton(driver);
        }
        
              
        [Then(@"I will verify the sent email will be shown in inbox")]
        public void ThenIWillVerifyTheSentEmailWillBeShownInInbox()
        {

            var driver = (IWebDriver)context["webdriver"];
            Thread.Sleep(5000);
            string subjectTitle = inbox.VerifySentEmailInInbox(driver);
            Assert.AreEqual(subjectTitle, "THIS IS A TEST " + stamp);

        }
        
        [Then(@"The email content can be validated")]
        public void ThenTheEmailContentCanBeValidated()
        {
            var driver = (IWebDriver)context["webdriver"];
            string emailBody = inbox.OpenTopEmail(driver);
            Assert.AreEqual(emailBody, "this is a test");
            inbox.ReturnToInbox(driver);
        }
        
        [Then(@"I will logout")]
        public void ThenIWillLogout()
        {
            var driver = (IWebDriver)context["webdriver"];
            inbox.LogOut(driver);
            Assert.IsTrue(logIn.VerifyLogOut(driver));
            DriverFactory.CloseDriver();
        }
    }
}
