using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using goog_specflow_POM.Pages;
using goog_specflow_POM;
using System.Threading;

namespace goog_specflow_POM.Steps
{
    [Binding]
       public class SendandVerifyEmailSteps
    {
        private readonly ScenarioContext context;
        static IWebDriver driver = null;
        //static IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("webdriver");
        LogInPage login = new LogInPage(driver);
      public SendandVerifyEmailSteps(ScenarioContext injectedContext)
        {
             context = injectedContext;
        }


    [Given(@"I connect to gmail website")]
        public void GivenIConnectToGmailWebsite()
        {
        var driver = context(driver);
            driver.Navigate().GoToUrl("https://www.google.com/gmail");
        //verify on correct page
        }
        
        [Given(@"I verify I successfully (.*) (.*) GMail account")]
        public void GivenIVerifyISuccessfullyLogIntoGMailAccount(string userName, string password)
        {

  //          LogInPage login = new LogInPage(driver);
            login.TypeUserName();
            Thread.Sleep(1000);
            login.PressUserButton();
            Thread.Sleep(1000);
            login.TypePassword();
            Thread.Sleep(1000);
            login.PressPasswordButton();
        }
        
        [When(@"I compose new email")]
        public void WhenIComposeNewEmail()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Send email to myself")]
        public void WhenSendEmailToMyself()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I verify I am on the Inbox page")]
        public void ThenIVerifyIAmOnTheInboxPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I will vefify the sent email will be shown in inbox")]
        public void ThenIWillVefifyTheSentEmailWillBeShownInInbox()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The email content can be validated")]
        public void ThenTheEmailContentCanBeValidated()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I will logout")]
        public void ThenIWillLogout()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
