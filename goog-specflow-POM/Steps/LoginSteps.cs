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
        private static readonly string CredentialsFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().
          Location) + "\\..\\..\\..\\configs\\Credentials.json";

        static IWebDriver driver = null;
        logIn login = new logIn(driver);
       
        readonly JObject fileReader = new ReadJSONFile().OpenJsonFile(CredentialsFilePath);
        public LoginSteps(ScenarioContext injectedContext, FeatureContext _featureContext)
        {
            context = injectedContext;
            featureContext = _featureContext;
        }

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

        [Given]
        public void I_enter_a_valid_USERNAME()
        {
            var driver = (IWebDriver)context["webdriver"];
            //Console.WriteLine(CredentialsFilePath);
            Console.WriteLine("Steve Hello1");
            string userName = "xxx";
            login.TypeUserName(driver, userName);
            login.PressUserButton(driver);
            //string xuserName = fileReader["gmail"]["logincreds"]["userName"].ToString();
            Console.WriteLine("Steve Hello2");
        }
        
        [Given]
        public void Given_I_enter_a_Valid_PASSWORD()
        {
            //string password = fileReader[featureContext["Environment"].ToString()][passwordType]["password"].ToString();
            var driver = (IWebDriver)context["webdriver"];
            string password = "zzz";
            login.TypePassword(driver, password);
            Thread.Sleep(1000);
        }
        
        [When]
        public void When_I_Click_on_Login_Button()
        {
            var driver = (IWebDriver)context["webdriver"];
            login.PressPasswordButton(driver);
        }
        
        [Then]
        public void Then_I_Verify_i_am_logged_in_successfully()
        {
            var driver = (IWebDriver)context["webdriver"];
            Thread.Sleep(5000);
            string home = driver.Url;
            Assert.IsTrue(home == "https://mail.google.com/mail/u/0/#inbox", "Failed to Login...");
        }
    }
}
