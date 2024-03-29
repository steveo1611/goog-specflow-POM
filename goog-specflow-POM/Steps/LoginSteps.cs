﻿using goog_specflow_POM.Pages;
using goog_specflow_POM.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        readonly common common = new common();

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
            string userName = fileReader["gmail"]["logincreds"]["userName"].ToString();
            login.TypeUserName(driver, userName);
            login.PressUserButton(driver);
        }
        
        [Given]
        public void Given_I_enter_a_Valid_PASSWORD()
        {
            var driver = (IWebDriver)context["webdriver"];
            string password = fileReader["gmail"]["logincreds"]["password"].ToString();
            login.TypePassword(driver, password);
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
            common.WaitForPageUrl(driver, "https://mail.google.com/mail/u/0/#inbox");
            string home = driver.Url;
            Assert.IsTrue(home == "https://mail.google.com/mail/u/0/#inbox", "Failed to Login...");
        }
       
    }
}
