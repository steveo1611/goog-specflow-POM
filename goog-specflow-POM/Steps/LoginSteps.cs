using goog_specflow_POM.Pages;
using goog_specflow_POM.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace goog_specflow_POM.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext context;
        private readonly FeatureContext featureContext;
        static IWebDriver driver = null;
        LogInPage login = new LogInPage(driver);
        public LoginSteps(ScenarioContext injectedContext, FeatureContext _featureContext)
        {
            context = injectedContext;
            featureContext = _featureContext;
        }
        readonly JObject fileReader = new ReadJSONFile().OpenJsonFile("configs\\Credentials.json");

        [Given(@"I am on ""(.*)"" website")]
        public void IAmOnWebsite(string webSiteName)
        {
            if
                (webSiteName == "Gmail")
            {
                webSiteName = ("https://www.google.com/gmail");
            }
            var driver = (IWebDriver)context["webdriver"]; 
            driver.Navigate().GoToUrl(webSiteName);
        }
        
        [Given(@"I enter a valid username")]
        public void GivenEnterAValidUsername(string userType)
        {
            // var driver = (IWebDriver)context["webdriver"];
            //string userName = fileReader[featureContext["Environment"].ToString()][userType]["userName"].ToString();
            string userName = "testfieldsteve";
            login.TypeUserName(driver, userName);
            Thread.Sleep(2000);
            login.PressUserButton();
        }
        
        [Given(@"I enter a valid (.*)")]
        public void GivenEnterAValidPassword(string passwordType)
        {
            //string password = fileReader[featureContext["Environment"].ToString()][passwordType]["password"].ToString();
            string password = "J0hn3:16";
            login.TypePassword(driver, password);
            Thread.Sleep(1000);
            login.PressPasswordButton();
        }
        
        [When(@"I click on Login button")]
        public void ClickOnLoginButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I verify i am logged in successfully")]
        public void VerifyIAmLoggedInSuccessfully()
        {
        //    var home = driver.Url;
         //   Assert.IsTrue(home == "https://mail.google.com/mail/u/0/#inbox");
        }
    }
}
