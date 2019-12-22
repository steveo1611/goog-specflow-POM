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
    public class logIn
    {
        private readonly IWebDriver driver;
        readonly By userName_txtfield = By.XPath("//*[@id='identifierId']");
        readonly By userButton = By.XPath("//*[@id='identifierNext']/span/span");
        readonly By password_txtfield = By.XPath("//*[@id='password']//input[@name='password']");
        readonly By passwordButton = By.XPath("//*[@id='passwordNext']//span[text()='Next']");
        readonly By passwordPage = By.Name("password");
        readonly By homePage = By.XPath("//*[@title='Gmail'");
        readonly By verifySignOut = By.XPath("//*[text()='Signed out']");

        public logIn(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void TypeUserName(IWebDriver driver, string userName)
        {
            driver.FindElement(userName_txtfield).SendKeys(userName);
        }
        public void PressUserButton(IWebDriver driver)
        {
            driver.FindElement(userButton).Click();
        }

        public void TypePassword(IWebDriver driver, string password)
        {
            driver.FindElement(password_txtfield).SendKeys(password);
        }

        public void PressPasswordButton(IWebDriver driver)
        {
            driver.FindElement(passwordButton).Click();
        }

        public bool VerifyLogOut(IWebDriver driver)
        {
            try
            {
                var element = driver.FindElement(verifySignOut);
                return element.Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
