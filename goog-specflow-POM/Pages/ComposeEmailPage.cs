using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using goog_specflow_POM.utils;

namespace goog_specflow_POM.Pages
{
    class ComposeEmailPage
    {
        private readonly IWebDriver driver;
        readonly By toReciept = By.XPath("//*[@name='to']");
        readonly By subject = By.XPath("//*[@name='subjectbox']");
        readonly By sendEmailButton = By.XPath("//*[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']");
        readonly By newMessageEmail = By.XPath("//*[@role='dialog']//div[2]//*[text()='New Message']");
      
        public ComposeEmailPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool ValidateEmailOpen(IWebDriver driver)
        {
            try
            {
                var element = driver.FindElement(newMessageEmail);
                return element.Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public void EnterToEmail(IWebDriver driver, string name)
        {
            driver.FindElement(toReciept).Click();
            driver.FindElement(toReciept).SendKeys(name);
        }
        public void EnterSubjectEmail(IWebDriver driver, string subjectLine)
        {
            driver.FindElement(toReciept).Click();
            driver.FindElement(subject).SendKeys(subjectLine);
        }
        public void EnterBodyText(IWebDriver driver, string bodyText)
        {
            driver.FindElement(By.XPath("//*[@role = 'textbox']")).SendKeys(bodyText);
        }

        public void clickSendEmailButton(IWebDriver driver)
        {
            driver.FindElement(sendEmailButton).Click();
        }


    }
}
