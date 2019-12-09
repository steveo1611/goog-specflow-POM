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
        readonly By passwordPage = By.Name("password");

        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void TypeUserName()
        {
            driver.FindElement(userName).SendKeys("zzz");
        }
        public void PressUserButton()
        {
            driver.FindElement(userButton).Click();
        }

        public void TypePassword()
        {
            driver.FindElement(password).SendKeys("zzz");
        }

        public void PressPasswordButton()
        {
            driver.FindElement(passwordButton).Click();
        }
    }
}
