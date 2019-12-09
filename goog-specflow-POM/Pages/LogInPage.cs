using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace goog_specflow_POM.Pages
{
   public class LogInPage
    {
        private readonly IWebDriver driver;
        readonly By userName = By.XPath("//*[@id='identifierId']");
        readonly By userButton = By.XPath("//*[@id='identifierNext']/span/span");
        readonly By password = By.XPath("//*[@id='password']//input[@name='password']");
        readonly By passwordButton = By.XPath("//*[@id='passwordNext']//span[text()='Next']");

        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void TypeUserName()
        {
            driver.FindElement(userName).SendKeys("Test");
        }
        public void PressUserButton()
        {
            driver.FindElement(userButton).Click();
        }

        public void TypePassword()
        {
            driver.FindElement(password).SendKeys(" ");
        }

        public void PressPasswordButton()
        {
            driver.FindElement(passwordButton).Click();
        }

        // user name
        // password
    }
}
