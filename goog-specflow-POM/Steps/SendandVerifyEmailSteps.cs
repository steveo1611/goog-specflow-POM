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
        private static readonly string CredentialsFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().
   Location) + "\\..\\..\\..\\configs\\Credentials.json";
        readonly JObject fileReader = new ReadJSONFile().OpenJsonFile(CredentialsFilePath);
        public SendandVerifyEmailSteps(ScenarioContext injectedContext )
        {
             context = injectedContext;
        }
       static readonly DateTime stamp = DateTime.Now;
       public static DateTime Stamp => stamp;
                
         
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
            string userName = fileReader["gmail"]["logincreds"]["userName"].ToString();
            string subject = fileReader["gmail"]["emailcontent"]["subject"].ToString();
            string bodytext = fileReader["gmail"]["emailcontent"]["bodytext"].ToString();
            inbox.SelectComposeButton(driver);
            Assert.IsTrue(compose.ValidateEmailOpen(driver));
            compose.EnterToEmail(driver, userName + "@gmail.com");
            compose.EnterSubjectEmail(driver, subject + stamp);
            compose.EnterBodyText(driver, bodytext);
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
            string subject = fileReader["gmail"]["emailcontent"]["subject"].ToString();
            string subjectTitle = inbox.VerifySentEmailInInbox(driver);
            Assert.AreEqual(subjectTitle, subject + stamp);

        }
        
        [Then(@"The email content can be validated")]
        public void ThenTheEmailContentCanBeValidated()
        {
            var driver = (IWebDriver)context["webdriver"];
            string emailBody = inbox.OpenTopEmail(driver);
            string bodytext = fileReader["gmail"]["emailcontent"]["bodytext"].ToString();
            Assert.AreEqual(emailBody, bodytext);
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
