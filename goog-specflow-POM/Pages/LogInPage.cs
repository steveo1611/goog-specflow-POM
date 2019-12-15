using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using goog_specflow_POM.utils;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace goog_specflow_POM.Pages
{
    public class LogInPage
    {
        private readonly IWebDriver driver;
        readonly JObject fileReader = new ReadJSONFile().OpenJsonFile("CredentialsFilePath");
        readonly By userName_txtfield = By.XPath("//*[@id='identifierId']");
        readonly By userButton = By.XPath("//*[@id='identifierNext']/span/span");
        readonly By password_txtfield = By.XPath("//*[@id='password']//input[@name='password']");
        readonly By passwordButton = By.XPath("//*[@id='passwordNext']//span[text()='Next']");
        readonly By passwordPage = By.Name("password");
        readonly By homePage = By.XPath("//*[@title='Gmail'");


        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void TypeUserName(IWebDriver driver, string userName)
        {
            // var driver = ScenarioContext.Current.Get<IWebDriver>("webdriver");
            driver.FindElement(userName_txtfield).SendKeys(userName);
        }
        public void PressUserButton()
        {
            driver.FindElement(userButton).Click();
        }

        public void TypePassword(IWebDriver driver, string password)
        {
            driver.FindElement(password_txtfield).SendKeys(password);
        }

        public void PressPasswordButton()
        {
            driver.FindElement(passwordButton).Click();
        }

        public void VerifyHomePage(IWebDriver driver)
        {
            var home = driver.FindElement(homePage);
            Assert.IsTrue(home == 'gmail');
        }
    }
}
